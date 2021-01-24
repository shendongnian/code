// Screen Touches
    Vector2?[] oldTouchPositions = {
        null,
        null
    };
    // Rotation Speed
    public float rotSpeed = 0.5f;
    public void Update()
    {
        if (Input.touchCount == 0)
        {
            oldTouchPositions[0] = null;
            oldTouchPositions[1] = null;
        }
        else if (Input.touchCount == 1)
        {
            if (oldTouchPositions[0] == null || oldTouchPositions[1] != null)
            {
                oldTouchPositions[0] = Input.GetTouch(0).position;
                oldTouchPositions[1] = null;
            }
            else
            {
                Vector2 newTouchPosition = Input.GetTouch(0).position;
                float distanceX = (oldTouchPositions[0] - newTouchPosition).Value.x;
                float distanceY = (oldTouchPositions[0] - newTouchPosition).Value.y;
                float rotX = distanceX * rotSpeed * Mathf.Deg2Rad;
                float rotY = distanceY * rotSpeed * Mathf.Deg2Rad;
                transform.Rotate(Vector3.up, rotX * 5, Space.Self);
                transform.Rotate(Vector3.left, rotY * 5, Space.Self);
                        
               
                oldTouchPositions[0] = newTouchPosition;
         
            }
        }
        else
        {
            if (oldTouchPositions[1] == null)
            {
                oldTouchPositions[0] = Input.GetTouch(0).position;
                oldTouchPositions[1] = Input.GetTouch(1).position;
            }
            else
            {
            }
        }
    }
