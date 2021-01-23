    public ActionResult Index()
    {
        var allPosts = DB.Posts.Include("Comments").ToList();
        return View(allPosts);
    } 
