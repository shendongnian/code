    protected void Page_Load(object sender, EventArgs e)
    {
        DataView dvSql = (DataView)CategoryNameSQL.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView drvSql in dvSql)
        {
            CategoryName.Text = drvSql["Name"].ToString();
        }   
    }
    protected void CategoryNameSQL_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.Parameters["Name"].Value = Request.QueryString["ID"];
    }
