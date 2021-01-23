    public static MvcHtmlString TextBoxWithPermission<TModel>(
        this HtmlHelper<TModel> htmlHelper,
        string name,
        object value,
        string[] permissions,
        object htmlAttributes
    )
    {
        foreach (string permission in permissions)
        {
            if (Chatham.Web.UI.Extranet.SessionManager.PhysicalUser.IsInRole(permission))
            {
                // the user has the permission => render the textbox
                return htmlHelper.TextBox(name, value, htmlAttributes);
            }
        }
    
        // the user has no permission => render a readonly checkbox
        var mergedHtmlAttributes = new RouteValueDictionary(htmlAttributes);
        mergedHtmlAttributes["disabled"] = "disabled";
        return htmlHelper.TextBox(name, value, mergedHtmlAttributes);
    }
