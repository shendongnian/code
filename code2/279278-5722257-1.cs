    MyRotateTransform.Angle += e.DeltaManipulation.Rotation;
    while (MyRotateTransform.Angle > 360)
    {
        MyRotateTransform.Angle -= 360;
    }
    while (MyRotateTransform.Angle < 360)
    {
        MyRotateTransform.Angle += 360;
    }
