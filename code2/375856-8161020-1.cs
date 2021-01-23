    //Page
    protected void Page_Load(object sender, EventArgs e)
    {
        test.Text = "Hello World!";
    }
    
    //User Control
    public string Text {get; set;}
    
    protected void Page_Load(object sender, EventArgs e)
    {
        lblTest.Text = Text;
    }
