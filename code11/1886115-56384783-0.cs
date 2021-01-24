    public ActionResult Index()
    {
       using (MvcBlogContext context = new MvcBlogContext())
       {
          List<Article> article= context.Article.GroupBy(x => x.Category)
                                .SelectMany(x => x.OrderByDescending(s => s.CreationDate).Take(1)).ToList();
          return View(article);
       }
    }
