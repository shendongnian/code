    public static string DoThis(this HtmlHelper helper)
    {
       string qs = helper.ViewContext.HttpContext.Request.QueryString.Get("val");
       //do something on it
    }
