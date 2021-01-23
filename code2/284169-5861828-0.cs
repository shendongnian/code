    public class SearchModel
    {
        public string Product { get; set; }
        public string Sku { get; set; }
        public string Size { get; set; }
        public string Manufacturer { get; set; }
        // etc...
   
        public PagedList ResultsList { get; set; }
    }
    [HttpPost]
    public ActionResult Results(SearchModel model)
    {
        model.ResultList = SearchManager.Search(model).ToList();
        return View(model);
    }
    
