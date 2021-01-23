    private void CollapseControl()
    {
        CollapseCommand.Content = "E";
        CollapseCommand.Margin = _btnMarginOnCollapse;
        BtnZoomIn.Visibility = Visibility.Collapsed;
        BtnZoomOut.Visibility = Visibility.Collapsed;
        ScrollViewerStackPanel.Visibility = Visibility.Collapsed;
        ZoomPanel.Visibility = Visibility.Collapsed;
        
        this.HorizontalAlignment = HorizontalAlignment.Left;
        LayoutTransform lt = new LayoutTransform();
        lt.Content = Nametb;
    
        RotateTransform nameRotateTransform = new RotateTransform();
        nameRotateTransform.Angle = 270;
    
        lt.LayoutTransform = nameRotateTransform;
        lt.ApplyLayoutTransform();
        Nametb.UpdateLayout();
    }
