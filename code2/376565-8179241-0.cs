    [WebMethod(EnableSession = true)]
    public static string HelloWorld(){
    if (User.Identity.IsAuthenticated)
    {
        return "Hello " + HttpContext.Current.Request.User.Identity.Name;
    }
    else
    {
        return "I don't talk to strangers";
    }
    }
