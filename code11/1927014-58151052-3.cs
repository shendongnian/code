using UnityEngine;
using System.Collections;
public class Example : MonoBehaviour
{
    public GameObject player;
    public PlayerMove move;
    void Start ()
    {
        move = player.GetComponent<PlayerMove>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            move.enabled = false;
            //Destroy(collision.gameObject);
        }
    }
}
