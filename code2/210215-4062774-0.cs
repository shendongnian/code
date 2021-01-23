    protected void Page_Load(object sender, EventArgs e)
    {
       if (!Page.IsPostBack)
       {
          ddl.DataSource = new List<string> { "1", "2", "3" };
          ddl.DataBind();
       }
    }
