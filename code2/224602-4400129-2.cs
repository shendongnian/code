    protected override void Initialize(RequestContext requestContext)
    {
       Lang = requestContext.RouteData.Values["lang"].ToString() 
       ?? System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
        
       ViewData["Lang"] = Lang;
       base.Initialize(requestContext);
       // your custom logic here...
    }
