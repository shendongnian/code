    public TestPage()
    {
        this.InitializeComponent();
        this.Loaded += TestPage_Loaded;
    }
    
    private void TestPage_Loaded(object sender, RoutedEventArgs e)
    {
        Messenger.Default.Register<string>(this, (s) =>
        {
            MyTextBlock.Text = s;
        });
    } 
