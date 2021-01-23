    protected void Page_Load(object sender, EventArgs e)
    {
        DataView dvSql = (DataView)CategoryNameSQL.Select(this.Request.QueryString["ID"]);
        foreach (DataRowView drvSql in dvSql)
        {
            CategoryName.Text = drvSql["Name"].ToString();
        }   
    }
