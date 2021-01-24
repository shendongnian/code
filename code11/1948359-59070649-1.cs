    private void Canvas_MouseWheel(object sender, MouseWheelEventArgs e)
    {
        var position = e.GetPosition((Canvas)sender);
        var center = new Point(
            Canvas.GetLeft(image) + image.ActualWidth / 2,
            Canvas.GetTop(image) + image.ActualHeight / 2);
        line.Data = new LineGeometry(center, position);
        point.Data = new EllipseGeometry(position, 3, 3);
    }
