    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        var request = filterContext.RequestContext.HttpContext.Request;
        var acceptTypes = request.AcceptTypes ?? new string[] {};
        var response = filterContext.HttpContext.Response;
        if (acceptTypes.Contains("application/json"))
        {
            WriteToResponse(filterContext, data, response, "application/json");
        }
        else if (acceptTypes.Contains("text/xml"))
        {
            WriteToResponse(filterContext, data, response, "text/xml");
        }
    }
    private void WriteToResponse(ActionExecutedContext filterContext, object data, HttpResponseBase response, String contentType)
    {
        response.ClearContent();
            response.ContentType = contentType;
            var length = Serializer.Serialize(data, response.ContentType, response.OutputStream);
            response.AddHeader("Content-Length", length.ToString());
            response.Flush();
            response.Close();
    }
