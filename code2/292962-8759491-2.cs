        public ActionResult Create()
        {
            Article article = new Article();
            article.Active = true;
            article.DatePublished = DateTime.Now;
            ViewData.Model = article;
            return View();
        } 
