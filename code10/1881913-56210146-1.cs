    void Update()
    {
        if(Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            float turnAngleChange = (touch.deltaPosition.x / Screen.width) * sensitivityX; 
            float pitchAngleChange = (touch.deltaPosition.y / Screen.height) * sensitivityY;
            // Handle any pitch rotation
            if (axes == RotationAxes.MouseXAndY || axes == RotationAxes.MouseY) {
                rotationY = Mathf.Clamp(rotationY+pitchAngleChange, minimumY, maximumY);
                transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0f));
            }
  
            // Handle any turn rotation
            if (axes == RotationAxes.MouseXAndY || axes == RotationAxes.MouseX) {
                transform.Rotate(0f, turnAngleChange , 0f);
            }
        }
    }
