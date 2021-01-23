    [HttpPost]
    public ActionResult Report(FormCollection collection)
    {
        var listofIDs = collection.ToList().Select(x => x.ToString());
        List<Dinner> dinners = new List<Dinner>();
        dinners = repository.GetDinners(listofIDs);
        return View(dinners);
    }
