    public static IHtmlString HrefLangLinks(this PageData currentPage)
    {
       var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
       var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();
    
       var links = currentPage.ExistingLanguages.Select(culture =>
             {
                var culturePage = contentLoader.Get<PageData>(currentPage.ContentGuid, new LanguageSelector(culture.Name));
                var culturePath = urlResolver.GetVirtualPath(culturePage.ContentLink, culturePage.Language.Name);
                return $"<link hreflang=\"{culture.Name}\" rel=\"alternate\" href=\"{culturePath.GetUrl()}\" >";
             });
    
       return new HtmlString(string.Join("",links));
    }
