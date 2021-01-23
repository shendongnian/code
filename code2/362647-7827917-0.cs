    MyEntities db = new MyEntities();
    IQueryable<HighScore> highscores = db.HighScores.OrderBy(s => s.Id);
    var pagedData = from v in highscores.AsPagination(page.GetValueOrDefault(1), 10).ToList();
    var transformedData = new CustomPagination<HighScoreModel>(pagedData.Select(v => GetUrlForImage(v.UserId,v.Score,v.IsAnonymous)), pagedData.PageNumber, pagedDate.PageSize, pagedData.TotalItems);
    return View(transformedData);
