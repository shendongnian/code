        public partial class Article
        {
            public Article()
            {
                Active = true;
                DatePublished = Datetime.Now;
            }
        }
        public ActionResult Create()
        {
            Article article = new Article();
            ViewData.Model = article;
            return View();
        } 
