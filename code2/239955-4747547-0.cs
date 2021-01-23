    protected void Page_Load(object sender, EventArgs e)
    {
    	DataSet dsSample = GetDataSet();
    	GridView gvSample;
    	if (dsSample.Tables.Count > 0 && dsSample.Tables[0].Rows.Count > 0)
    	{
    		for (int iCount = 0; iCount < dsSample.Tables.Count; iCount++)
    		{
    			gvSample = new GridView();
    			gvSample.DataSource = dsSample.Tables[iCount];
    			gvSample.DataBind();
    			plcSample.Controls.Add(gvSample);
    		}
    	}
    
    }
    
    private DataSet GetDataSet()
    {
    	DataSet ds = new DataSet();
    	DataTable dt;
    
    	dt = new DataTable();
    	dt.Columns.Add(new DataColumn("ID", typeof(string)));
    	dt.Columns.Add(new DataColumn("Code", typeof(string)));
    	DataRow dr;
    	dr = dt.NewRow();
    	dr["ID"] = 1;
    	dr["Code"] = "KK";
    	dt.Rows.Add(dr);
    	dr = dt.NewRow();
    	dr["ID"] = 2;
    	dr["Code"] = "Karan";
    	dt.Rows.Add(dr);
    	ds.Tables.Add(dt);
    
    	dt = new DataTable();
    	dt.Columns.Add(new DataColumn("ID", typeof(string)));
    	dt.Columns.Add(new DataColumn("Code", typeof(string)));
    	dr = dt.NewRow();
    	dr["ID"] = 1;
    	dr["Code"] = "AA";
    	dt.Rows.Add(dr);
    	dr = dt.NewRow();
    	dr["ID"] = 2;
    	dr["Code"] = "Arun";
    	dt.Rows.Add(dr);
    	ds.Tables.Add(dt);
    
    	return ds;
    }
 
