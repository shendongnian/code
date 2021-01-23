    [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
    public string Contents
    {
    	get
    	{
    		string contents = (string)ViewState["Contents"];
    		return (contents == null) ? String.Empty : contents;
    	}
    	set
    	{
    		ViewState["Contents"] = value;
    	}
    }
