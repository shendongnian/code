    MyRotateTransform.Angle += e.DeltaManipulation.Rotation;
    while (MyRotateTransform.Angle > 2 * Math.PI)
    {
        MyRotateTransform.Angle -= 2 * Math.PI;
    }
    while (MyRotateTransform.Angle < 2 * Math.PI)
    {
        MyRotateTransform.Angle += 2 * Math.PI;
    }
