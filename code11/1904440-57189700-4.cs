    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPos = (Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            var rotationX = ((Input.mousePosition).x - lastPos.x) * rotationSpeed;
            transform.Rotate(Vector3.up, -rotationX, Space.World);
            lastPos = Input.mousePosition;
        }
    }
