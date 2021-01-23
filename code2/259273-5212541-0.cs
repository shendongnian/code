    filterContext.Result = new ContentResult
    {
    	ContentType = "text/plain",
    	Content = "Access Denied. Invalid user name and/or password."
    };
   
    filterContext.HttpContext.Response.Status = "500 ".Replace("\r", " ").Replace("\n", " ");
