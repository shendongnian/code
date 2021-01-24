    public ActionResult Create(ArticleCreateModel model)
    {
        if(ModelState.IsValid())
        {
            ArticleBustinessLogic.Create(ArticleCreateModel model);
            return RedirectToAction("Index");
            // Or simply
            // var article = new Article();
            // article.Id = Guid.NewGuid().ToString();
            // article.Title = model.Title();
            // ArticleRepository.Create(article);
            // ArticleSubcription.NotifySubscribers(article);
            // return RedirectToAction("Index");
        }
        return View();
    }
