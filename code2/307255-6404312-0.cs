    [Authorize]
    public ActionResult UpdateArticle(ArticleModel model, int articleid)
    {
        // if current user is an article editor
        return View();
        // else
        return View("Error");
    }
