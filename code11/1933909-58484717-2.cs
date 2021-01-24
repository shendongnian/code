    public IActionResult CreateArticle()
        {
            ViewBag.TitleList = _context.Articles.Select(a => a.Title).ToList();
            return View();
        }
