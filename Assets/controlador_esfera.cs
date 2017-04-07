using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlador_esfera : MonoBehaviour
{

    public float speed;
    private int count;
    public Text text;
    public Text wintext;


    private void Start()
    {
        count = 0;
        updateCounter();
        wintext.text= "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        GetComponent<Rigidbody>().AddForce(direction * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "pickup")
        {
            Destroy(other.gameObject);
            count++;
            updateCounter();
        }
        
    }
    void updateCounter()
    {
        text.text = "Puntos: " + count;
        int numPickups = GameObject.FindGameObjectsWithTag("pickup").Length;
        if (numPickups == 1)
        {
            wintext.text = "Has ganado!";
        }
    }
}