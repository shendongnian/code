    public ActionResult Map()
    {
        GeneralStore gs = new GeneralStore();
        ViewData["Cities"] = gs.GetCitiesHaveSaleCenter();
        ViewData["Areas"] = gs.GetAllAreas();
        var saleCenters = gs.GetAllSaleCenters();
        return View(saleCenters);
    }
