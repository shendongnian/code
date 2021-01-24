    protected void Page_Load(object sender, EventArgs e)
    {
    	DataTable dt = new DataTable();
    	dt.Columns.AddRange(new DataColumn[1] { new DataColumn("empno", typeof(int)) });
    	for (int i = 0; i < 10; i++)
    	{
    		DataRow dr;
    		dr = dt.NewRow();
    		dr["empno"] = i.ToString("00");
    
    		dt.Rows.Add(dr);
    
    		GridView1.DataSource = dt;
    		Session["dt"] = dt;
    		GridView1.DataBind();
    	}
    }
    
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
    	GridView1.EditIndex = e.NewEditIndex;
    	GridView1.DataSource = Session["dt"] as DataTable;
    	GridView1.DataBind();
    }
