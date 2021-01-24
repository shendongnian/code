    [HttpGet("{selectedNewsid")]
    public ActionResult Index(int selectedNewsid = 0)
    {
        if(selectedNewsid == 0)
        {
           //Show all news images
        }else{
            List<NewsImage> newsImages = db.NewsImages.Include(n => n.News).Where(c => c.NewsId == selectedNewsid).ToList();
            ViewBag.NewsTitle = newsImages[1].News.Title;
            return View(newsImages);
        }
    }
