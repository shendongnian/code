    // Your naming is very confusing ... Min should be the smaller value
    public float MaxAltNeedleRotation = 135f;
    public float MinAltNeedleRotation = -65f;
    private float alreadyRotated = 0;
    public void update ()
    { 
        var direction = 0;
        // use && here .. you don't want to do a bitwise & on bools
        if (Input.GetAxisRaw("Vertical") > 0 && alreadyRotated < MaxAltNeedleRotation)
        {
            direction = 1;
        }
        // use else if since anyway only one of the cases can be true
        else if (Input.GetAxisRaw("Vertical") < 0 && alreadyRotated > MinAltNeedleRotation)
        {
            direction = -1;
        }
        // use the rotation and riection
        // but clamp it so it can minimum be MinAltNeedleRotation - alreadyRotated
        // and maximum MaxAltNeedleRotation - alreadyRotated
        var rotation = Mathf.Clamp(direction * 15f * Time.deltaTime, MinAltNeedleRotation - alreadyRotated, MaxAltNeedleRotation - alreadyRotated);
        if(rotation != 0)
        {
            AltNeedleBright.transform.Rotate(Vector3.forward * rotation);
            // update the alreadyRotated value
            alreadyRotated += rotation;
        }
    }
