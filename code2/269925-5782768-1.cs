    public ActionResult Index()
            {
                var table = new Post();
                var posts = table.All();
    
                return View(posts);
            }
