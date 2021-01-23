    bool show = (bool)value;
    bool visible = (bool)parameter;
    if (visible)
    {
        return show ? Visibility.Visible : Visibility.Collapsed;
    }
    else
    {
        return show ? Visibility.Collapsed : Visibility.Visible;
    }
