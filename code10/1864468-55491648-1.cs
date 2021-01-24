    [HttpGet]
    [AllowAnonymous]
    public ActionResult Article(int id)
    {
      using (MatrodyEntities db = new MatrodyEntities())
      {
        db.NewsData.Find(ArtID);
        return View("Article", id);
      } 
    }
