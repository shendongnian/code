    private Point m_clickDelta;
    private void Polyline_MouseDown(object sender, MouseButtonEventArgs e)
    {
        Point position = e.GetPosition(myCanvas);
        m_clickDelta.X = position.X - Canvas.GetLeft(myPolyline);
        m_clickDelta.Y = position.Y - Canvas.GetTop(myPolyline);
        myPolyline.CaptureMouse();
    }
    private void Polyline_MouseUp(object sender, MouseButtonEventArgs e)
    {
        myPolyline.ReleaseMouseCapture();
    }
    private void Polyline_MouseMove(object sender, MouseEventArgs e)
    {
        if (myPolyline.IsMouseCaptured == true)
        {
            Point position = e.GetPosition(myCanvas);
            Canvas.SetLeft(myPolyline, position.X - m_clickDelta.X);
            Canvas.SetTop(myPolyline, position.Y - m_clickDelta.Y);
        }
    }
