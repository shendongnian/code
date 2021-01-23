	string cFinalQueryString = "";
	if(!IsPostBack)
	{
		if (Page.Request.QueryString["cell"] != null)
		{
			cFinalQueryString = Page.Request.QueryString["cell"];
		}else{
			//do nothing, empty string
		}
    }
    else
    {
    	cFinalQueryString = txtCell.Text;
    }
    
	txtCell.Text = cFinalQueryString;
	Lookup_Cell(cFinalQueryString);
