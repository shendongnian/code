    public ActionResult Details(int actorId)
    {
        PAPEntities db = new PAPEntities();
        SeriesViewModel[] SeriesVM = db.SeriesParticipated.Where(o => o.ActorId == actorId).Include(o => o.SeriesData).Select(o => new SeriesViewModel
        {
            SerieID = o.SeriesData.SerieID,
            SerieName = o.SeriesData.SerieName,
            SerieCategory = o.SeriesData.SerieCategory,
            SerieDescription = o.SeriesData.SerieDescription,
            SerieYear = o.SeriesData.SerieYear
        }).ToArray();
        return View(SeriesVM);
    }
