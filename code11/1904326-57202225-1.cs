    private void Awake()
    {
        RotateX = transform.rotation.euerAngles.y;
        RotateY = Camera.transform.localRotation.eulerAngles.x;
    }
    
    void Rotation()
    {
        RotateX += Input.GetAxis("Mouse X") * RorationSpeed;
        RotateY += Input.GetAxis("Mouse Y") * RorationSpeed;
        RotateY = Mathf.Clamp(RotateY, MinYAxis, MaxYAxis);
        Camera.transform.localRotation = Quaternion.Euler(-RotateY, 0f, 0f);
        transform.rotation = Quaternion.Euler(0f, RotateX, 0f);
    }
