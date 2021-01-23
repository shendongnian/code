    [HttpPost]
    public ActionResult Results(SearchModel model)
    {
        ResultsModel results = new ResultsModel();
        results.ResultList = SearchManager.Search(model).ToList();
    
        TempData["SearchModel"] = model;
    
        return View("Results", results);
    }
    
        [HttpGet]
        public ActionResult Results(int? page)
        {
            SearchModel model = (SearchModel)TempData["SearchModel"];
        
            ResultsModel results = new ResultsModel();
            results.ResultList = SearchManager.Search(model).ToList();
        
            TempData["SearchModel"] = model;
        
            return View("Results", results);
        }
