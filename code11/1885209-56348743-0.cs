    void Update () {
        if (Input.touchCount > 0 ) 
        { 
            Touch touch = Input.GetTouch(0);
 
            float yMove = touch.deltaPosition.y / Screen.height;
            transform.Translate(Vector2.up * yMove * speed);
    
            if (transform.position.y < -19)
            {
                transform.position = startPos;
            }
        }
    
    }
