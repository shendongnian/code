    protected void Application_EndRequest()
    {
    	var context = new HttpContextWrapper(Context);
 	if (Context.Response.StatusCode == 302 && context.Request.IsAjaxRequest())
    	{
    		Context.Response.Clear();
    		Context.Response.StatusCode = 308;
    	}
    }
