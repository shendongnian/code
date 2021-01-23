    string ComingUrl = "";
    if (Request.UrlReferrer != null)
    {
        ComingUrl = System.Web.HttpContext.Current.Request.UrlReferrer.ToString();
    }
    else
    {
        ComingUrl = "Direct"; // Your code
    }
