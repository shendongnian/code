    void MyMethod(string something, object parameters)
    {
    RouteValueDictionary dic = HtmlHelper.AnonymousObjectToHtmlAttributes(options);
    }
    
    MyMethod("test", new { @myFirstParam=""some kind of text", anotherParam=42);
