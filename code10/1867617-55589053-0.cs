    public Dictionary<string, string> CreateWorkingLanguageDictionary(this PageData currentPage)
    	{
    		var languageDictionary = new Dictionary<string, string>();
    		var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
    		var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();
    		
    		foreach (string cultureName in availablePageLanguages)
    		{
    			var culturePage = contentLoader.Get<PageData>(currentPage.ContentGuid, new LanguageSelector(cultureName));
    			var culturePath = urlResolver.GetVirtualPath(culturePage.ContentLink, culturePage.Language.Name);
    			languageDictionary.Add(cultureName, culturePath.GetUrl());
    		}
    
    		return languageDictionary;
    	}
    
    	public IList<IHtmlString> CreateLanguageLinksList(Dictionary<string, string> langs)
    	{
    		var htmlStringList = new List<IHtmlString>();
    		foreach (KeyValuePair<string, string> entry in langs)
    		{
    			htmlStringList.add(new HtmlString("<link hreflang=\"{0}\" rel=\"alternate\" href=\"{1}\" >", langs.Keys, langs.Values));
    		}
    
    		return htmlStringList;
    	}
