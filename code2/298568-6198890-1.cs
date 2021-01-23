    void DisableAllButtons(FrameworkElement fe)
    {
        if (fe is Button)
            ((Button)(fe)).IsEnabled = false;
        int count = VisualTreeHelper.GetChildrenCount(fe);
        for (int index = 0; index < count; ++index)
        {
            DisableAllButtons( (FrameworkElement)VisualTreeHelper.GetChild(fe, index) );
        }
    }
