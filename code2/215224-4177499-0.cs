    protected void Page_Load(object sender, EventArgs e)
    {
    	if (Page.IsPostBack)
    		return;
    		
    	radioButtonList1.SelectedIndex = 0;
    	ListBox1_SelectedIndexChanged(null, null);
    }
    
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
    	LoadContent(ListBox1.SelectedIndex);
    }
