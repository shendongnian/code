    public List<MyItemType> MyItems { get; set; }
    public Window1()
    {
        InitializeComponent();
        
        MyItems = new List<MyItemType>();
        MyItemType newItem = new MyItemType();
        newItem.Image = ... load BMP here ...;
        newItem.Title = "FooBar Icon";
        MyItems.Add(newItem);
        this.MainGrid.DataContext = this;
    }
