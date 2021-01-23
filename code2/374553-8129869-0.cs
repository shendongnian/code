    var httpContext = new HttpContextWrapper(HttpContext.Current);
    var pageContext = new WebPageContext(httpContext, webPage, null);
    
    var sb = new StringBuilder();
    using (var writer = new StringWriter(sb))
    {
       webPage.ExecutePageHierarchy(pageContext, writer);
    }
    
    string output = sb.ToString();
