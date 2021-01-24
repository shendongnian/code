    private void Awake()
    {
        RotateX = transform.rotation.eulerAngles.y;
        RotateY = Camera.transform.localRotation.eulerAngles.x;
        if (RotateY > 180)
        {
            RotateY = -(360 - RotateY);
        }
    }
    private void Rotation()
    {
        RotateX += Input.GetAxis("Mouse X") * RorationSpeed;
        RotateY -= Input.GetAxis("Mouse Y") * RorationSpeed;
        RotateY = Mathf.Clamp(RotateY, MinYAxis, MaxYAxis);
        Camera.transform.localRotation = Quaternion.Euler(RotateY, 0f, 0f);
        transform.rotation = Quaternion.Euler(0f, RotateX, 0f);
    }
