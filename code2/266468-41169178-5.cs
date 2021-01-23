    public static TagBuilder GetCanonicalUrl(RouteData route,String host,string protocol)
    {
        //These rely on the convention that all your links will be lowercase! 
        string actionName = route.Values["action"].ToString().ToLower();
        string controllerName = route.Values["controller"].ToString().ToLower();
        //If your app is multilanguage and your route contains a language parameter then lowercase it also to prevent EN/en/ etc....
        //string language = route.Values["language"].ToString().ToLower();
        string finalUrl = String.Format("{0}://{1}/{2}/{3}/{4}", protocol, host, language, controllerName, actionName);
        var canonical = new TagBuilder("link");
        canonical.MergeAttribute("href", finalUrl);
        canonical.MergeAttribute("rel", "canonical");
        return canonical;
    }
