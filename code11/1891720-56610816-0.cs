    // Your naming is very confusing ... Min should be the smaller value
    public float MaxAltNeedleRotation = 135f;
    public float MinAltNeedleRotation = -65f;
    private float alreadyRotated = 0;
    public void update ()
    { 
        float rotation = 0;
        // use && here .. you don't want to do a bitwise & on bools
        if (Input.GetAxisRaw("Vertical") > 0 && alreadyRotated < MaxAltNeedleRotation)
        {
            // get the smaller of both values
            rotation = Mathf.Min(MaxAltNeedleRotation - alreadyRotated, 15f * Time.deltaTime);
        }
        // use else if since anyway only one of the cases can be true
        else if (Input.GetAxisRaw("Vertical") < 0 && alreadyRotated > MinAltNeedleRotation)
        {
            // Since dealing with a negative value get the bigger of both values
            rotation = Mathf.Max(MinAltNeedleRotation - alreadyRotated, -15f * Time.deltaTime);
        }
        if(rotation != 0)
        {
            AltNeedleBright.transform.Rotate(Vector3.forward * rotation);
            // update the alreadyRotated value
            alreadyRotated += rotation;
        }
    }
