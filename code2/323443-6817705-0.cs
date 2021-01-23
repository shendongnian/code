    bool state = false;
    Point prePoint;
    private void btn_MouseMove(object sender, MouseEventArgs e)
    {
    if (state)
    {
        Point p = e.GetPosition(this);
        Point p2 = e.GetPosition(btn);
        btn.Margin = new Thickness(0, p.Y - p2.Y + p.Y - prePoint.Y, 0, 0);
        prePoint = e.GetPosition(this);
        // Capture Mouse here ! as far as i think. !!!
        Mouse.Capture(this.ColorPlane, CaptureMode.Element);
    }
    else
    {
        // Release Mouse here ! as far as i think. !!!
        Mouse.Capture(null);
    }
    }
