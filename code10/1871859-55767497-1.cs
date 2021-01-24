    private void ScrollViewer_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
    {
        ScrollViewer scrollViewer = sender as ScrollViewer;
        double offset = scrollViewer.VerticalOffset - Math.Sign(e.Delta);
        scrollViewer.ScrollToVerticalOffset(Math.Min(Math.Max(offset, 0), scrollViewer.ExtentHeight));
        e.Handled = true;
    }
