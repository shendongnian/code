using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class El_carmen : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform El_carmenPlace;
    private Vector2 initialPosition;
    private float deltaX, deltaY;
    public static bool locked;
    private Rigidbody rb;
    //use this for initialiozation
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.touchCount > 0 && !locked)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                        rb.isKinematic = true;
                        rb.detectCollisions = true;
                    }
                    break;
                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    break;
                case TouchPhase.Ended:
                    initialPosition = transform.position;
                    if (Mathf.Abs(transform.position.x - El_carmenPlace.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - El_carmenPlace.position.y) <= 0.5f)
                    {
                        
                        rb.MovePosition(transform.position = new Vector2(El_carmenPlace.position.x, El_carmenPlace.position.y));
                        rb.isKinematic = true;
                        rb.detectCollisions = true;
                        locked = true;
                    }
                    else if (locked == false)
                    {
                        transform.position = new Vector2(initialPosition.x, initialPosition.y);
                        rb.isKinematic = false;
                        rb.detectCollisions = false;
                    }
                    break;
            }
        }
    }
   
    
}
im trying with an if hoping it will work :c
