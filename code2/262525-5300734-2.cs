        [GridAction(EnableCustomBinding = true)]
        public ActionResult AjaxBinding(int page, int category)
        {
            var searchResultsViewModel = //Code to get search results
            
            return View(new GridModel
                            {
                                Data = searchResultsViewModel.SearchResults,
                                Total = searchResultsViewModel.TotalCount
                            });
        }
