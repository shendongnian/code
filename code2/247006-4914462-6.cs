    void ellipse_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton != MouseButtonState.Pressed)
            return;
        ellipse.CaptureMouse();
        var scaleAnimate = new DoubleAnimation(1.25,
            new Duration(TimeSpan.FromSeconds(1)));
        scale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnimate);
        scale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnimate);
        // We are going to move the center of the ellipse to the mouse
        // location immediately, so start the animation with a shift to
        // get it back to the current center and end the animation at 0.  
        var offsetInEllipse = e.GetPosition(ellipse);
        translate.BeginAnimation(TranslateTransform.XProperty, 
            new DoubleAnimation(ellipse.Width / 2 - offsetInEllipse.X, 0, 
                new Duration(TimeSpan.FromSeconds(1))));
        translate.BeginAnimation(TranslateTransform.YProperty, 
            new DoubleAnimation(ellipse.Height / 2 - offsetInEllipse.Y, 0, 
                new Duration(TimeSpan.FromSeconds(1))));
        MoveEllipse(e);
    }
    void ellipse_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.LeftButton != MouseButtonState.Pressed || !ellipse.IsMouseCaptured)
            return;
        MoveEllipse(e);
    }
    private void MoveEllipse(MouseEventArgs e)
    {
        var pos = e.GetPosition(canvas);
        Canvas.SetLeft(ellipse, pos.X - ellipse.Width / 2);
        Canvas.SetTop(ellipse, pos.Y - ellipse.Height / 2);
    }
