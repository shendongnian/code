    public static IHtmlString HrefLangLinks(this PageData currentPage)
    {
    
    var hrefLangTags = string.Empty;
    var availablePageLanguages = currentPage.ExistingLanguages.Select(culture => culture.Name).ToArray();
    var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
    var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();
    foreach (string cultureName in availablePageLanguages)
    {  
        var culturePage = contentLoader.Get<PageData>(currentPage.ContentGuid, new LanguageSelector(cultureName));
        var culturePath = urlResolver.GetVirtualPath(culturePage.ContentLink, culturePage.Language.Name);
        hrefLangTags += String.Format("<link hreflang=\"{0}\" rel=\"alternate\" href=\"{1}\" >", culturName, culturePath.GetUrl());
    }
    return new HtmlString(hrefLangTags);
    }
