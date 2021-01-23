    private void OnPinchStarted(object sender, PinchStartedGestureEventArgs e)
    {
        initialAngle = transform.Rotation;
        initialScale = transform.ScaleX;
    }
    private void OnPinchDelta(object sender, PinchGestureEventArgs e)
    {
        //transform.Rotation = initialAngle + e.TotalAngleDelta;
        transform.ScaleX = initialScale * e.DistanceRatio;
        transform.ScaleY = initialScale * e.DistanceRatio;
    }
