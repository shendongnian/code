    static String previousSQL_Query;
    protected void Page_Load(object sender, EventArgs e)
    {
      if(IsPostBack)
      {
        SqlDataSource2.SelectCommand = previousSQL_Query;
      }
      else
      {
           SqlDataSource2.SelectCommand = "select * from manager";
           managerList.AllowPaging = true;
      }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SqlDataSource2.SelectCommand = "select * from manager where age > 30";
        previousSQL_Query = SqlDataSource2.SelectCommand;
        managerList.DataBind();
    }
