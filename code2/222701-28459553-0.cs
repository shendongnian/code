    void Test()
    {
        var linkText = @"Help Spread DuckDuckGo!";
        Console.WriteLine(GetHyperlinkUrl("duckduckgo.com", linkText));
        // as of right now, this would print ‘https://duckduckgo.com/spread’
    }
    /// <summary>
    /// Loads pageUrl, finds a hyperlink containing searchLinkText, returns
    /// its URL if found, otherwise an empty string.
    /// </summary>
    public string GetHyperlinkUrl(string pageUrl, string searchLinkText)
    {
        using (IWebDriver phantom = new PhantomJSDriver())
        {
            phantom.Navigate.GoToUrl(pageUrl);
            var link = phantom.FindElement(By.PartialLinkText(searchLinkText));
            if(link != null)
                return link.GetAttribute("href");
        }
        return string.Empty;
    }
