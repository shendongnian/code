    public static MvcHtmlString MyCheckBoxFor<TModel>(
        this HtmlHelper<TModel> htmlHelper,
        string permission, 
        Expression<Func<TModel, bool>> expression, object htmlAttributes
    )
    {
        if (permission == "foo bar")
        {
            // the user has the foo bar permission => render the checkbox
            return htmlHelper.CheckBoxFor(expression, htmlAttributes);
        }
        // the user has no permission => render empty string
        return MvcHtmlString.Empty;
    }
