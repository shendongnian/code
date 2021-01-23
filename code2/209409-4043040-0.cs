    public static readonly DependencyProperty IsInReadModeProperty = DependencyProperty.Register(
        "IsInReadMode",
        typeof(bool),
        typeof(RegCardSearchForm),
        new UIPropertyMetadata(false, ReadModeChanged));
    
    private static void ReadModeChanged(DependencyObject dObj, DependencyPropertyChangedEventArgs e)
    {
        RegCardSearchForm form = dObj as RegCardSearchForm;
        if (form != null)
            form.ReadModeChanged((bool)e.OldValue, (bool)e.NewValue);
    }
    
    protected virtual void ReadModeChanged(bool oldValue, bool newValue)
    {
        // TODO: Add your instance logic.
    }
