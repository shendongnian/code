    public string StaticText
    {
        get { return (string)this.GetValue(StaticTextProperty); }
        set { this.SetValue(StaticTextProperty, value); } 
    }
    public static readonly DependencyProperty StaticTextProperty = 
        DependencyProperty.Register("StaticText", typeof(string), 
        typeof(MyControl),new PropertyMetadata(false));
