    protected void Page_Load(object sender, EventArgs e)
    {
    if (!IsPostBack)
        {
        SqlDataSource2.SelectCommand = "select * from manager";
        managerList.AllowPaging = true;
        }
    
    }
