    [Description("My Description"), Category("Visibility")]
    public string ConnectorLabelText
    {
        get { return (string)GetValue(ConnectorLabelTextProperty); }
        set { SetValue(ConnectorLabelTextProperty, value); }
    }
