    public static readonly DependencyProperty CustomNestedValueProperty =
        DependencyProperty.Register("CustomNestedValue",
                                    typeof (bool),
                                    typeof (NestedUserControl),
                                    null);
    public bool CustomNestedValue
    {
        get { return (bool) GetValue (CustomNestedValueProperty); }
        set { SetValue (CustomNestedValueProperty, value); }
    }
