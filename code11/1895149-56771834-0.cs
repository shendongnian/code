    protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }
    public void BindData()
    {
        string strConnection = @"Data Source=.\sa;Initial Catalog=Northwind;Integrated Security=SSPI;";
        SqlConnection con = new SqlConnection(strConnection);
        con.Open();
        SqlCommand cmd = new SqlCommand("select ProductId, ProductName, SupplierId from Products", con);
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
		int rowcount = ds.Tables[0].Rows.Count;
		int remainingCount = 10 - (rowcount % 10);
		for (int i = 0; i < remainingCount; i++)
		{
			DataRow row = ds.Tables[0].NewRow();
			ds.Tables[0].Rows.Add(row);
		}
        GridView1.DataSource = ds;
        GridView1.DataBind();
        con.Close();  
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindData();  
    }
