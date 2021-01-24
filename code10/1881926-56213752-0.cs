    private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
    {
        var mouseWheelEventArgs = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
        mouseWheelEventArgs.RoutedEvent = ScrollViewer.MouseWheelEvent;
        mouseWheelEventArgs.Source = sender;
        this.parentScrollViewer.RaiseEvent(mouseWheelEventArgs);
    }
