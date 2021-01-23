    protected void Page_Load(object sender, EventArgs e)
    {
    	int id = 0;
    	ImageButton ib = new ImageButton
    	{
    		CommandName = "Edit",
    		CommandArgument = id.ToString(),
    		ImageUrl = "~/Images/icons/paper_pencil_48.png",
    		AlternateText = "Edit document"
    	};
    	ib.Command += ImageButton_OnCommand;
    
    	form1.Controls.Add(ib);
    }
