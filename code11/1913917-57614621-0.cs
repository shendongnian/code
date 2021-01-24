using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Test : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("click");
            rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
        }
        rotate();
    }
    private void rotate()
    {
    }
}
I also edited my old script to this:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ArrowController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 50.0f;
    public Vector2 pos;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        faceMouse();
        testForClick();
    }
    void FixedUpdate()
    {
        if (doForce == true)
        {
            doForce = false;
            rb.AddForce(transform.forward * speed, ForceMode2D.Impulse);
        }
    }
    private bool doForce;
    private GameObject gunArm;
    private Camera cam;
    private void faceMouse()
    {
        // try to reuse the reference
        if (!cam) cam = Camera.main;
        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        // try to re-use the reference
        if (!gunArm) gunArm = GameObject.Find("gunArm");
        var difference = rb.transform.position - mousePos;
        var gunAngle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        rb.transform.rotation = Quaternion.Euler(0, 0, gunAngle);
    }
    void testForClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("click");
            // only set the flag
            doForce = true;
        }
    }
    void place()
    {
        
    }
}
and the test worked by itself with no rotation and on the main script only the rotation worked so i tried having both scripts active at the same time and it started working, thanks for all the help on this issue.
