    private Point mousePos;
    private void ImageMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var image = (Image)sender;
        image.CaptureMouse();
        mousePos = e.GetPosition(image);
        selectionPath.Data = new RectangleGeometry(new Rect(mousePos, mousePos));
    }
    private void ImageMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        var image = (Image)sender;
        image.ReleaseMouseCapture();
        selectionPath.Data = null;
    }
    private void ImageMouseMove(object sender, MouseEventArgs e)
    {
        var rect = selectionPath.Data as RectangleGeometry;
        if (rect != null)
        {
            var image = (Image)sender;
            rect.Rect = new Rect(mousePos, e.GetPosition(image));
        }
    }
