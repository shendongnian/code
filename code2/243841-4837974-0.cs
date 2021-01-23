    class SearchModel
    {
        public PageModelA { get; set; }
        public PageModelB { get; set; }
    }
    
    [HttpPost]
    public ActionResult Search(SearchModel search)
    {
        if (SearchModel.PageModelA != null)
        {
            //Do something with PageModelA
        }
        else
        {
            //Do something with PageModelB
        }
    }
