    protected void Application_EndRequest(object sender, EventArgs e)
        {
         
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.StatusCode = 200;
            }
    
        }
