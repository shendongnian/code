    // System.Web.HttpContext
    /// <summary>Gets or sets the <see cref="T:System.Web.HttpContext" /> object for the current HTTP request.</summary>
    /// <returns>The <see cref="T:System.Web.HttpContext" /> for the current HTTP request.</returns>
    public static HttpContext Current
    {
    	get
    	{
    		return ContextBase.Current as HttpContext;
    	}
    	set
    	{
    		ContextBase.Current = value;
    	}
    }
