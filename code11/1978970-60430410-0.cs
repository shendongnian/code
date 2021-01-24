    if (Input.GetKey(KeyCode.LeftShift))
    {
        Camera.current.fieldOfView += 80 * Time.deltaTime;
        speed = 10f;
        flySpeed = 6;
    }
    else
    {
        Camera.current.fieldOfView -= 250 * Time.deltaTime;
        speed = 7f;
        flySpeed = 4;
    }
