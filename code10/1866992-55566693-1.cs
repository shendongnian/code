    // I just directly used Transform here
    // to save a bit of coding later
    public Transform steeringWheel;
    public Transform followGO;
    private void Update()
    {
        // returns the position of followGO relative to the steeringwheel
        // but in the local transform space of the steering wheel itself
        var relativePosition = steeringWheel.InverseTransformDirection(followGO.position);
        // you want to eliminate the local difference in Y direction
        relativePosition.y = 0;
        // since you are right and LookAt expects a world position after eliminating the local Y difference 
        // we convert it back to world space
        var targetPosition = steeringWheel.TransformPoint(relativePosition);
        steeringWheel.transform.LookAt(targetPosition, steeringWheel.transform.up);
    }
    
