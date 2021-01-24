    public GameObject AltNeedleBright;
    float MaxAltNeedleRotation = 135f; //smaller than this
    float MinAltNeedleRotation = -65f; // bigger than this
    public void Update ()
    {
        float zAxis = AltNeedleBright.transform.localRotation.eulerAngles.z;
        float input = Input.GetAxisRaw("Vertical"); //Returns -1 or 1
        if(input > 0 && WrapAngle(zAxis) < MaxAltNeedleRotation)
        {
            AltNeedleBright.transform.Rotate(0, 0, 15 * Time.deltaTime);
        }
        if(input < 0 && WrapAngle(zAxis) > MinAltNeedleRotation)
        {
            AltNeedleBright.transform.Rotate(0, 0, -15 * Time.deltaTime);
        }
    }
    private static float WrapAngle(float angle)
    {
        angle %= 360;
        if(angle > 180)
            return angle - 360;
        return angle;
    }
