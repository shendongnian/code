    public static MvcHtmlString MyHelper<T, TProperty>(
        this HtmlHelper<T> html,
        Expression<Func<T, TProperty>> prop)
    {
        var obj = // ??
        var value = prop(obj); \\ get the value of Prop1 (not the name "Prop1")
        ...
    }
