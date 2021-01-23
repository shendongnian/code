    bool test;
    public bool MyPostBack
    {
        get{ return test; }
        set{ test = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
         MyPostBack = Page.IsPostBack;
    }
