    void Update()
        {
            if (Input.GetMouseButton(1))
            {
                   float XaxisRotation = Input.GetAxis("Mouse Y")*10f;
                   transform.Rotate (Vector3.right, XaxisRotation);
            }
    }
