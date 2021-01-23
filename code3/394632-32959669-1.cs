    protected override void OnInit(System.EventArgs e)
    {
    	// this assigns Page_PreLoad as the event handler 
    	// for the PreLoad event of the Control's Page property
    	this.Page.PreLoad += Page_PreLoad;
    	base.OnInit(e);
    }
    
    private void Page_PreLoad(object sender, System.EventArgs e)
    {
    	// do something here
    }
