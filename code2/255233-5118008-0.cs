    /// <summary>
    /// GET: /Loan/Search/LastName/Smith/2
    /// Displays search results.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public ActionResult Search(SearchType searchType, string s, [DefaultValue(1)]int page)
    {
        try
        {
            int batch = 20;
            int fromRecord = 1;
            int toRecord = batch;
            if(page != 1)
            {
                toRecord = (batch * page);
                fromRecord = (toRecord - (batch-1));
               
            }
            var widgets= _repos.Search(searchType, s, fromRecord, toRecord );
            if (loans.Count == 0)
            {
                InfoMsg("No results were found.");
            }
            if (Request.IsAjaxRequest())
            {        
                if(widgets.Count > 0)
                {
                    return View("SearchResultsLineItems", widgets);
                }
                else
                {
                    return new ContentResult
                    {
                        ContentType = "text/html",
                        Content = "noresults",
                        ContentEncoding = System.Text.Encoding.UTF8
                    };
                }
                
            }
            return View("SearchResults", widgets);
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }
