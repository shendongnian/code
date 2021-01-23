    public JobQuote Quote
    {
    	get
    	{
    		JobQuote result = ViewState["Quote"] as JobQuote;
    		if (result == null)
    		{
    			result = new JobQuote();
    			ViewState["Quote"] = result;
    		}
    		
    		return result;
    	}
    }
