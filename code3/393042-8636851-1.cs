    public static readonly DependencyProperty NameProperty= 
        DependencyProperty.Register(
        "Name", typeof(string),
    ...
        );
    public string Name
    {
        get { return (string)GetValue(NameProperty); }
        set { SetValue(NameProperty, value); }
    }
