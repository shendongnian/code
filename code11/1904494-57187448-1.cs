    #region public string MyText
    /// <summary>
    /// This the dependency property for the control.
    /// </summary>
    public string MyText
    {
        get { return GetValue(MyTextProperty) as string; }
        set { SetValue(MyTextProperty, value); }
    }
    
    /// <summary>
    /// Identifies the MyText dependency property.
    /// </summary>
    public static readonly DependencyProperty MyTextProperty =
        DependencyProperty.Register(
            "MyText",
            typeof(string),
            typeof(InvoiceControl),
            new PropertyMetadata(string.Empty));
    #endregion public string MyText
