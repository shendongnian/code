    internal static readonly DependencyPropertyKey TargetPropertyKey =
        DependencyProperty.RegisterReadOnly(
            "Target",
            typeof(bool),
            typeof(MyControl));
    public static readonly DependencyProperty TargetProperty =
        TargetPropertyKey.DependencyProperty;
    
    public bool Target
    {
        get { return (bool)GetValue(TargetProperty); }
        protected set { SetValue(TargetProperty, value); }
    }
