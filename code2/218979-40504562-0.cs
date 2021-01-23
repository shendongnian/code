    [WebMethod]
    public static string mywebmethod()
    {
    string parameters =  HttpContext.Current.Request.UrlReferrer.PathAndQuery.ToString();
    return parameters
    }
