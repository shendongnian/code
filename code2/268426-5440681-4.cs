    public TestWindow()
    {
        InitializeComponent();
    
        this.DataContext = this;
    }
    
    private Person _P1 = new Person();
    
    public Person P1
    {
        get { return _P1; }
        set { _P1 = value; }
    }
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
    
    }
