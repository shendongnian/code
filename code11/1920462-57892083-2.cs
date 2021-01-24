    // set via the Inspector
    public float speedInUnitsPerSecond = 1;
    private Vector2 lastDirection;
    
    privtae void Update()
    {
        ...
        // If the finger is on the screen, move the object smoothly to the touch position
        var touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
        lastDirection = (touchPosition - transform.position).normalized;
         
        ...
        // move with constant speed in the last direction
        transform.Translate(lastDirection * Time.deltaTime * speedInUnitsPerSecond);
        ...
    }
