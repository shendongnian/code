    private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var success = rectangle.CaptureMouse();
    }
    private void Rectangle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        rectangle.ReleaseMouseCapture();
        Point p = e.GetPosition(rectangle);
        if (new Rect(0, 0, rectangle.ActualWidth, rectangle.ActualHeight)
            .Contains(p))
        {
            Debug.WriteLine("Mouse up inside rectangle.");
        }
        else
        {
            Debug.WriteLine("Mouse up outside rectangle.");
        }
    }
