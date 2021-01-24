    public static readonly DependencyProperty MyTextProperty =
        DependencyProperty.Register(nameof(MyText), typeof(string), typeof(Wizard));
    public string MyText
    {
        get { return (string)GetValue(MyTextProperty); }
        set { SetValue(MyTextProperty, value); }
    }
