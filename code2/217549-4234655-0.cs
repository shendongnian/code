    [Description("My Description"), Category("Layout")]
    public string Something
    {
        get { return (string)GetValue(SomethingProperty); }
        set { SetValue(SomethingProperty, value); }
    }
