    public string PathToVideo { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        //--- replace with your path
        PathToVideo = Page.ResolveClientUrl("~/videos/filename.flv");
    }
