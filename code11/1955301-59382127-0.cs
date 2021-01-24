    public ActionResult Filter()
    {
        var viewModel = new Location();
        viewModel.Patients = db.Locations.ToList();
        return View(viewModel);
    }
