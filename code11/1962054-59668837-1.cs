    private float oldAngle;
    private float newAngle;
    private void Start()
    {
        // store initial value
        oldAngle = FindAngle(v1, v2, v3);
    }
    private void Update()
    {
        // compare to current value
        newAngle = FindAngle(v1, v2, v3);
        if(oldAngle > newAngle)
        {
            // Do something
        }
    }
