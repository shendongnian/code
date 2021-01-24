            public ActionResult Search(string category, SearchViewModel categories)
        {
            if (categories == null) categories = new SearchViewModel { };
            if (categories.Categories == null) categories.Categories = new List<SearchCategory>();
            if (category != null) categories.Categories.Add(new SearchCategory { Category = category }); // add category to the list
            return View(categories);
        }
