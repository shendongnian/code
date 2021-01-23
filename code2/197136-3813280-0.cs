    public static MvcHtmlString ActiveActionLink (this HtmlHelper helper, string labelText, string action, string controller)
    {
        var cssProprties = controller;
        // if this controller is the target controller, page is active.
        if (helper.ViewContext.RouteData.Values["controller"].ToString() == controller)
            cssProprties += " active";
        return helper.ActionLink(labelText, action, controller, null, new { @class = cssProprties });
    }
