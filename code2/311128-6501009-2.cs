    [HttpGet]
    public ActionResult NewBlogPost()
    {
         return View();
    }
    [HttpPost]
    public ActionResult NewBlogPost()
    {
         BlogPost newBlogPost = new BlogPost();
         TryUpdateModel<INewBlogPost>(newBlogPost);
         if (ModelState.IsValid) { ... }
    }
