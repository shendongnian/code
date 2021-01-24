        public ActionResult YourSearchPage()
        {
            //Bind the data to a list here
            List<YourResultType> result = //Get from DB
            return View(result);
        }
   
        //When the user clicks the "Search" button
        [HttpPost]
        public ActionResult YourSearchPage(string keyword, int listingType...)
        {
            //Bind the data to a list here
            List<YourResultType> result = //Get from DB
            ViewBag.keyword = keyword;
            ViewBag.listingType = listingType;
            //Filter the list
            return View(result);
        }
