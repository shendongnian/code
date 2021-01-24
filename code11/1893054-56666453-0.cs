    [HttpGet("{selectedNewsId")]
    public ActionResult Index(int selectedNewsid = 0)
    {
        List<NewsImage> newsImages = db.NewsImages.Include(n => n.News).Where(c => c.NewsId == selectedNewsid).ToList();
        ViewBag.NewsTitle = newsImages[1].News.Title;
        return View(newsImages);
    }
