    public void ProcessRequest(RequestContext requestContext)
    {
        var response = requestContext.HttpContext.Response;
        var request = requestContext.HttpContext.Request;
        int width = 100;
        if(requestContext.RouteData.Values["width"] != null)
        {
            width = int.Parse(requestContext.RouteData.Values["width"].ToString());
        }
        ...
        response.ContentType = "image/png";
        response.BinaryWrite(buffer);
        response.Flush();
    }
