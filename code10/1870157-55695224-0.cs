    float Speed = 50f;
    float sensitivity = 5f;
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    private Vector2 initialPos;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            // store the current position
            initialPos = transform.position;
        }
        // I would just make it exclusive else-if since you don't want to 
        // move in the same frame anyway
        else if (Input.GetMouseButton(0))
        {
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentSwipe = secondPressPos - firstPressPos;
            if (firstPressPos != secondPressPos)
            {
                // Now use the initialPos + currentSwipe
                transform.position = Vector2.Lerp(transform.position, initialPos + currentSwipe / 200, sensitivity * Time.deltaTime);
            }
        }
    }
