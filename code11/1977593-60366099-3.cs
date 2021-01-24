using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Move : MonoBehaviour
{
    public float moveSpeed = 20f;
    public VirtualJoystick moveJoystick;
    public Rigidbody rb;
    private Vector3 dir = Vector3.zero;
    private bool wasMoving = false;
    private void Update()
    {
        dir.x = moveJoystick.Horizontal();
        dir.z = moveJoystick.Vertical();
        if (dir.magnitude > 0)
        {
            wasMoving = true;
        }
    }
    private void FixedUpdate()
    {
        if (wasMoving && dir.magnitude == 0f)
        {
            wasMoving = false;
            rb.Sleep();
        }
        rb.AddForce(dir * moveSpeed);
    }
}
It's also a good idea to store the `Rigidbody` as a variable so you don't recompute it every update. Be sure to drag it into the script from the inspector.
