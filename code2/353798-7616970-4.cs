    public MainWindow()
    {
        MyObjects = new List<MyObject>();
        MyObject item1 = new MyObject();
        item1.MyValue = string.Format("100");
        MyObjects.Add(item1);
        MyObject item2 = new MyObject();
        item2.MyValue = string.Format("120");
        MyObjects.Add(item2);
        MyObject item3 = new MyObject();
        item3.MyValue = string.Format("140");
        MyObjects.Add(item3);
        MyObject item4 = new MyObject();
        item4.MyValue = string.Format("160");
        MyObjects.Add(item4);
        InitializeComponent();
        DataContext = this;
    }
