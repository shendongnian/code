    public void Page_Load()
    {
        if (!Page.IsPostBack)
        {
            grid.DataSource = GetDataSource();
            grid.DataBind();
        }
    }
