    public static MvcHtmlString Foo(this HtmlHelper htmlHelper)
    {
        var value = htmlHelper.ViewContext.HttpContext.Request["paramName"];
        ...
    }
