    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GridView1.DataSource = GetSomeData();
            GridView1.DataBind();
        }
    }
