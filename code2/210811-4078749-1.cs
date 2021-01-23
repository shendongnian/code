    protected void Page_Load(object sender, EventArgs e)
    {
    	DataList1.DataSource = new[] {
    		new Staff {
    			ID = 1, Name = "Staff 1"
    		},
    		new Staff {
    			ID = 2, Name = "Staff 2"
    		}
    	};
    	DataList1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
    	Panel panel1 = DataList1.Items[0].FindControl("Panel1") as Panel;
    
    	if (panel1 != null)
    	{
    		Label label1 = panel1.FindControl("Label1") as Label;
    		if (label1 != null)
    			label1.Text = "Found!";
    	}
    }
