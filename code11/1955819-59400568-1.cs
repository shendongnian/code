    public List<SearchResultModel> GetAllResults(SearchResultsOptions searchResultsOptions)
    {
        List<SearchResultModel> toReturn = new List<SearchResultModel>();
        IList<IWebElement> results =  driver.FindElements(By.css("my locattors"))
    
        foreach(IWebElement element in results)
        {
            SearchResultModel result = new SearchResultModel();
            result.Title = searchResultsOptions.Title? element.FindElement(By.css("some locator")).GetText(): null;
            result.IsPrime = searchResultsOptions.IsPrime? element.FindElement(By.css("some locator")).Selected(): false;
            result.Price = searchResultsOptions.Price? element.FindElement(By.css("some locator")).GetText(): null;
            // add more fields here
            toReturn.Add(result);
        }
    
        return toReturn;
    }
