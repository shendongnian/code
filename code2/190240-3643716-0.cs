    private void frame_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        UpdateFrameDataContext();
    }
    private void frame_LoadCompleted(object sender, NavigationEventArgs e)
    {
        UpdateFrameDataContext();
    }
    private void UpdateFrameDataContext(object sender, NavigationEventArgs e)
    {
        var content = frame.Content as FrameworkElement;
        if (content == null)
            return;
        content.DataContext = frame.DataContext;
    }
