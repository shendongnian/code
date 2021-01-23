    public enum MyEnum
    {
        Facebook = 19,
        Twitter = 20,
        YouTube = 21,
        Flickr = 23,
        Blogs = 25,
    }
    
    public Form1(MyEnum collectorID)
    {
        InitializeComponent();
        this.CollectorID = collectorID;
        labelCollector.Text = collectorId.toString();
        WebConnection.Create(CollectorID);
    }
