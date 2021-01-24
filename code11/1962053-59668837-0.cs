    private float oldAngle;
    private float newAngle;
    private void Start()
    {
        oldAngle = FindAngle(v1, v2, v3);
    }
    private void Update()
    {
        newAngle = FindAngle(v1, v2, v3);
        if(oldAngle > newAngle)
        {
            // Do something
        }
    }
