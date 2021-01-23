    private Point startPoint;
    private void toggleButton_PreviewMouseLeftButtonDown(
        object sender, MouseButtonEventArgs e)
    {
        startPoint = e.GetPosition(toggleButton);
    }
    private void toggleButton_PreviewMouseMove(object sender, MouseEventArgs e)
    {
        var currentPoint = e.GetPosition(toggleButton);
        if (e.LeftButton == MouseButtonState.Pressed &&
            toggleButton.IsMouseCaptured &&
            (Math.Abs(currentPoint.X - startPoint.X) >
                SystemParameters.MinimumHorizontalDragDistance ||
            Math.Abs(currentPoint.Y - startPoint.Y) >
                SystemParameters.MinimumVerticalDragDistance))
        {
            // Prevent Click from firing
            toggleButton.ReleaseMouseCapture();
            DragMove();
        }
    }
