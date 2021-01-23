    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostback())
        {
            BindData(Request.QueryString["EntityId"]);
        }
    }
