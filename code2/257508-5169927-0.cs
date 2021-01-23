    protected void Page_Load(object sender, EventArgs e)
    {
    	if (Session["AdminOk"] != null)
    	{	
    		bool bAdminOk = false;
    		try
    		{
    			bAdminOk = (bool) Session["AdminOk"];
    		}
    		catch
    		{
    		}
    		if (!bAdminOk)
    		{	
    			Response.Redirect("~/Admin/login.aspx");
    		}
    
    	}
    }
