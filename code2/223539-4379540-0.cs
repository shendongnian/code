    HttpContext.Current = new HttpContext(
        new HttpRequest("", "http://tempuri.org", ""),
        new HttpResponse(new StringWriter())
        );
    HttpContext.Current.User = new GenericPrincipal(
        new GenericIdentity("username"),
        new string[0]
        );
