    public static readonly DependencyProperty AProperty = DependencyProperty.Register("A", typeof(double), typeof(MainWindow),
        new PropertyMetadata(new PropertyChangedCallback(OnAChanged)));
    public double A
    {
        get { return (double)GetValue(AProperty); }
        set { SetValue(AProperty, value); }
    }
    private static void OnAChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        MainWindow window = (MainWindow)d;
        window.B = window.A;
    }
    public static readonly DependencyProperty BProperty = DependencyProperty.Register("B", typeof(double), typeof(MainWindow));
    public double B
    {
        get { return (double)GetValue(BProperty); }
        set { SetValue(BProperty, value); }
    }
