    public ActionResult Index(int? page)
    {
      var itemsPerPage = 5;
      var db = new MyEntities();
      var totalItems = db.HighScores.Count();
      IQueryable<HighScore> highscores = db.HighScores.OrderBy(highscore => highscore.ID);
      var pagedData = from highscore in highscores.AsPagination(page.GetValueOrDefault(1), itemsPerPage).ToList()
                      select highscore;
      var transformedData = new CustomPagination<HighScoreModel>(pagedData.Select(highscore => TransformData(highscore)), 
                                                                 page.HasValue ? page.Value : 1, 
                                                                 itemsPerPage,
                                                                 totalItems);
      return View(transformedData);
    }
