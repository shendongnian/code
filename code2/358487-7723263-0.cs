    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            test.Text = Request.QueryString["blog_ID"];
        }
    }
