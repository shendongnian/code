    public static MvcHtmlString TextBoxForWithPermission<TModel>(
        this HtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, bool>> expression,
        string[] permissions,
        object htmlAttributes
    )
    {
        foreach (string permission in permissions)
        {
            if (Chatham.Web.UI.Extranet.SessionManager.PhysicalUser.IsInRole(permission))
            {
                // the user has the permission => render the textbox
                return htmlHelper.TextBoxFor(expression, htmlAttributes);
            }
        }
    
        // the user has no permission => render a readonly checkbox
        var mergedHtmlAttributes = new RouteValueDictionary(htmlAttributes);
        mergedHtmlAttributes["disabled"] = "disabled";
        return htmlHelper.TextBoxFor(expression, mergedHtmlAttributes);
    }
