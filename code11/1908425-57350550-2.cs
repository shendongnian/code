    private float? lastMousePoint = null;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePoint = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0)) {
            lastMousePoint = null;
        }
        if (lastMousePoint != null)
        {
            float difference = Input.mousePosition.x - lastMousePoint.Value;
            transform.position = new Vector3(transform.position.x + (difference / 188) * Time.deltaTime, transform.position.y, transform.position.z);
            lastMousePoint = Input.mousePosition.x;
        }
    }
