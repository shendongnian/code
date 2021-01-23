    public static readonly DependencyProperty Source1Property =
        DependencyProperty.Register(
            "Source1",
            typeof(bool),
            typeof(MyControl),
            new FrameworkPropertyMetadata(false, new PropertyChangedCallback(UpdateTarget)));
    
    public bool Source1
    {
      get { return (bool)GetValue(Source1Property); }
      set { SetValue(Source1Property, value); }
    }
    
    void UpdateTarget(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        MyControl self = (MyControl)d;
        d.Target = d.Source1 && d.Source2;
    }
