    var rotateTransform = element.RenderTransform as RotateTransform;
    if (rotateTransform == null)
    {
        rotateTransform = new RotateTransform();
        element.RenderTransform = rotateTransform;
        element.RenderTransformOrigin = new Point(0.5, 0.5);
    }
    rotateTransform.Angle += 30;
