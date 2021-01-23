    public string Test
    {
        get { return (string)this.GetValue(TestProperty); }
        set { this.SetValue(TestProperty, value); }
    }
    public static readonly DependencyProperty TestProperty =
        DependencyProperty.Register("Test",
        typeof(string),
        typeof(MainWindow),
        new PropertyMetadata("CCC", TestPropertyChanged));
    private static void TestPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
    {
        MainWindow mainWindow = source as MainWindow;
        string newValue = e.NewValue as string;
        // Do additional logic
    }
