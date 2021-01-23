    public static MyCompanyHtmlHelpers GetInstance(HtmlHelper htmlHelper)
    {
        const string key = "MyCompanyHtmlHelpersInstance";
        IDictionary items = (htmlHelper == null || htmlHelper.ViewContext == null
            || htmlHelper.ViewContext.HttpContext == null)
            ? HttpContext.Current.Items : htmlHelper.ViewContext.HttpContext.Items;
        MyCompanyHtmlHelpers obj = (MyCompanyHtmlHelpers)items[key];
        if (obj == null)
        {
            items.Add(key, obj = new MyCompanyHtmlHelpers());
        }
        return obj;
    }
