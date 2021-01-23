    public List<MyItemType> MyItems { get; set; }
    public Window1()
    {
        InitializeComponent();
        
        MyItems = new List<MyItemType>();
        MyItems.Add(...code to create item here...);
        this.MainGrid.DataContext = this;
    }
