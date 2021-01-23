    public MainWindow()
    {
        InitializeComponent();
        for (int i = 0; i < 10; i++)
        {
            Border hu = new Border();
            hu.Width = 10;
            hu.Height = 10;
            hu.Margin = new Thickness(10 * i);
            hu.Tag = anyObject;
            hu.MouseDown += new MouseButtonEventHandler(hu_MouseDown);
        }
    }
    void hu_MouseDown(object sender, MouseButtonEventArgs e)
    {
        Border b = (Border)sender;
        // b.Tag contains your "anyObject"
    }
