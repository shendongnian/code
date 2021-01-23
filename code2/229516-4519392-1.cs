    public static MvcHtmlString Username(this HtmlHelper htmlHelper)
    {
        var identity = htmlHelper.ViewContext.HttpContext.User.Identity;
        if (identity.IsAuthenticated)
        {
            return MvcHtmlString.Create(identity.Name);
        }
        return MvcHtmlString.Empty;
    }
