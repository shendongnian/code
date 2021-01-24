    private static void OnThumbPosChanged(DependencyObject relatedObject, DependencyPropertyChangedEventArgs e)
    {
        if (this.Visibility == Visibility.Collapsed)
        {
           return
        }
        XYController xycontroller = relatedObject as XYController;
        if (xycontroller != null)
        {
            xycontroller.m_thumbTransform.X = xycontroller.ThumbPosX * xycontroller.ActualWidth;
            xycontroller.m_thumbTransform.Y = xycontroller.ThumbPosY * xycontroller.ActualHeight;
        }
    }
