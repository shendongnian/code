    if ( ( HttpContext.Current.Handler as Page )?.IsAsync ?? false )
    {
    
    	if ( transfer )
    	{
    		HttpContext.Current.Server.Execute( page, false );
    		HttpContext.Current.Response.Flush();
    		Thread.CurrentThread.Abort();
    	}
    	else
    	{
    		HttpContext.Current.Response.Redirect( page, false );
    		Thread.CurrentThread.Abort();
    	}
    }
    else
    {
    	if ( transfer )
    	{
    		HttpContext.Current.Server.Transfer( page, false );
    	}
    	else
    	{
    		HttpContext.Current.Response.Redirect( page );
    	}
    }
