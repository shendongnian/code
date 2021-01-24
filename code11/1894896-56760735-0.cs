    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                deltaRotation = 0f;
                previousRotation = angleBetweenPoints(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                currentRotation = angleBetweenPoints(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                deltaRotation = Mathf.DeltaAngle(currentRotation, previousRotation);
                if (Mathf.Abs(deltaRotation) > deltaLimit)
                {
                    deltaRotation = deltaLimit * Mathf.Sign(deltaRotation);
                }
                previousRotation = currentRotation;
                transform.Rotate(Vector3.back * Time.deltaTime, deltaRotation);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                transform.Rotate(Vector3.back * Time.deltaTime, deltaRotation);
                deltaRotation = Mathf.Lerp(deltaRotation, 0, deltaReduce * Time.deltaTime);
            }
        }
    }
