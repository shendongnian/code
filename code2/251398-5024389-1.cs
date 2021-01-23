    protected void rblContentTypesGetAll_Load(object sender, EventArgs e)
    {
    	if (IsPostBack)
    	{
    		return;
    	}
    	var dt = new DataTable();
    	using (var con = new SqlConnection(Global.conString))
    	using (var cmd = new SqlCommand("contentTypeGetAll", con))
    	using (var da = new SqlDataAdapter(cmd))
    	{
    		da.Fill(dt);
    	}
    	//Clear Items before reloading
    	rblContentTypesGetAll.Items.Clear();
    
    	//Populate Radio button list
    	for (int i = 0; i < dt.Rows.Count; i++)
    	{
    		rblContentTypesGetAll.Items.Add(new ListItem(dt.Rows[i]["contentType"].ToString() + " - " + dt.Rows[i]["description"].ToString(),
    			dt.Rows[i]["ID"].ToString()));
    	}
    
    	//Set Default Selected Item by Value
    	rblContentTypesGetAll.SelectedIndex = rblContentTypesGetAll.Items.IndexOf(rblContentTypesGetAll.Items.FindByValue(((siteParams)Session["myParams"]).DefaultContentType.ToLower()));
    }
