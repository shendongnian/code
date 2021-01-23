    public MainWindow()
    {
      this.DataContext = this;
      MyString = "Hi there...";
      InitializeComponent();
    }
    public string MyString { get; set; }
