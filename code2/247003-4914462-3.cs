    private Point offsetInEllipse;
    void ellipse_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton != MouseButtonState.Pressed)
            return;
        ellipse.CaptureMouse();
        offsetInEllipse = e.GetPosition(ellipse);
        var scaleAnimate = new DoubleAnimation(1.25,
            new Duration(TimeSpan.FromSeconds(1)));
        scale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnimate);
        scale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnimate);
    }
    void ellipse_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.LeftButton != MouseButtonState.Pressed || !ellipse.IsMouseCaptured)
            return;
        var pos = e.GetPosition(canvas);
        Canvas.SetLeft(ellipse, pos.X - offsetInEllipse.X);
        Canvas.SetTop(ellipse, pos.Y - offsetInEllipse.Y);
    }
    void ellipse_MouseUp(object sender, MouseButtonEventArgs e)
    {
        if (!ellipse.IsMouseCaptured)
            return;
        ellipse.ReleaseMouseCapture();
        var scaleAnimate = new DoubleAnimation(1,
            new Duration(TimeSpan.FromSeconds(1)));
        scale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnimate);
        scale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnimate);
    }
