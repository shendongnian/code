    public void OnTitleBarLayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args)
    {
        var bar = sender as CoreApplicationViewTitleBar;
        RightPanel.Margin = new Thickness(0, 0, bar.SystemOverlayRightInset, 0);
    }
