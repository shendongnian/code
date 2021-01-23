    private static string GetPageTitle(string url)
    {
    	HtmlWeb web = new HtmlWeb();
    	HtmlDocument doc = web.Load(url);
    
    	var result = doc.DocumentNode
    		.DescendantNodes()
    		.FirstOrDefault(node =>
    			string.Compare(
    				node.Name,
    				"title",
    				StringComparison.InvariantCultureIgnoreCase) == 0);
    
    	return result != null ? result.InnerHtml : string.Empty;
    }
