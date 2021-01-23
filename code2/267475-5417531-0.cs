        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Search()
        {
            SearchPageModel Model = new SearchPageModel();
            // populate the Model properties
            Model.ImageURL = "myjpeg"
            return View("Search", Model);
        }
