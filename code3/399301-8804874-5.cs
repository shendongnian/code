    [HttpPost]
    public ActionResult GetSearchResults(string searchText)
    {
        // Here, you should query your database for results based
        // on the given search text. Then, you can create a view
        // using those results and send it back to the client.
        var model = GetSearchResultsModel(searchText);
        return View(model);
    }
