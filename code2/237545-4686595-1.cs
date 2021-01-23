    public static string MyCustomHelper(this HtmlHelper htmlHelper, string someValue, object htmlAttributes)
    {
        return htmlHelper.MyCustomHelper(someValue, new RouteValueDictionary(htmlAttributes));
    }
    public static string MyCustomHelper(this HtmlHelper htmlHelper, string someValue, IDictionary<string, object> htmlAttributes)
    {
        // Get attributes with htmlAttributes["name"]
        ...
    }
