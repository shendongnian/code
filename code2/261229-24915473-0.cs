    private string[] data = new string[] { "first", "second", "third" };
    protected int ItemCount { get; set; }
    
    private void Page_Load(object sender, EventArgs e)
    {
        // normally one would fetch the data here right before binding like this:
        // data = SomeService.SomeMethodToGetData();
        repeater.DataSource = data;
        repeater.DataBind();
    }
    
    public override void DataBind()
    {
        ItemCount = data.Count();
    }
    
    protected string GetItemClass(int itemIndex)
    {
        if (itemIndex == 0)
            return "first";
        else if (itemIndex == this.ItemCount - 1)
            return "last";
        else
            return "other";
    }
