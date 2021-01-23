    public static readonly DependencyProperty EnableEndFilterProperty =
        DependencyProperty.Register(
        "EnableEndFilter", 
        typeof(bool), 
        typeof(TimeframeSelector), 
        new FrameworkPropertyMetadata(false, 
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
