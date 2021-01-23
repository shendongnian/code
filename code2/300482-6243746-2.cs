    {
        public DateTime Date{get;set;}
    	public string Title{get;set;}
    	public string Prefix
    	{get
    		{
    			return Title.Substring(0,Title.LastIndexOf(' '));
    		}
    	}
    }
