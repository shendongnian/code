    public static string CustomerHelper( this HtmlHelper helper, ... )
    {
        var model = helper.ViewData.Model as ISessionModel;
        var sessionKey = model.SessionKey;
        ...
    }
