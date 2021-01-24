using UnityEngine;
using System.Collections;
public class ExampleClass : MonoBehaviour
{
    public PlayerMove move;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            move.enabled = false;
        }
    }
}
