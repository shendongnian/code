    IEnumerator OnTriggerEnter2D(Collider2D ball)
    {
        yield return new WaitForFixedUpdate();
    
        // The assignment of the GameObject
        // was kind of redundant except
        // you need the reference for something else later
    
        ballRb = ball.GetComponent<Rigidbody2D>();
        ballRb.position = this.transform.position;
        // Freeze the ball
        ballRb.velocity = Vector2.zero;
        // Rotate the ball using the Rigidbody component
        // Was the int overload intented here? Returning int values 0-359
        // otherwise rather use the float overload by passing float values as parameters
        ballRb.rotation = Random.Range(0f, 360f);
        // Start moving the ball again
        // with a Vector different to Vector2.zero e.g.
        ballRb.velocity = Vector2.right * ballController.bulletSpeed;
    }
