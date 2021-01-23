    protected void Page_Load(object sender, EventArgs e)
    {
    	if (Page.IsPostBack)
    		return;
    
    	//create dummy data
    	List<string> rows = new List<string>();
    	Enumerable.Range(1, 5).ToList().ForEach(x => rows.Add(x.ToString()));
    
    	//bind dummy data to gridview
    	GridView1.DataSource = rows;
    	GridView1.DataBind();
    }
    
        protected void CheckBox1_CheckChanged(object sender, EventArgs e)
        {
        	//cast sender to checkbox
        	CheckBox CheckBox1 = (CheckBox)sender;
        
        	//retrieve the row where checkbox is contained
        	GridViewRow row = (GridViewRow)CheckBox1.NamingContainer;
        
        	//find the label in the same row
        	Label Label1 = (Label)row.FindControl("Label1");
        
        	//logics
        	if (CheckBox1 != null)  //make sure checkbox1 is found
        	{
        		if (CheckBox1.Checked)
        		{
        			if (Label1 != null) //make sure label1 is found
        			{
        				Label1.Text = "Checked";
        			}
        
        		}
        		else
        		{
        			if (Label1 != null)
        			{
        				Label1.Text = "Unchecked";
        			}
        		}
        	}
        }
