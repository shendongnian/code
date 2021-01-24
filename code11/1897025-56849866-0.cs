csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Moving : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] float accelerationForce = 5f;
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            rigidbody.AddForce(Vector3.forward * accelerationForce, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.S))
            rigidbody.AddForce(Vector3.back * accelerationForce, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.D))
            rigidbody.AddForce(Vector3.right * accelerationForce, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.A))
            rigidbody.AddForce(Vector3.left * accelerationForce, ForceMode.Impulse);
    }
}
You also can check [this tutorial](https://www.youtube.com/watch?v=MBDWTjn05eg) and [this other tutorial](https://www.youtube.com/watch?v=3AB0R606bRk).
