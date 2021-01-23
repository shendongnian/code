    public ActionResult Insert(SomeViewModel model)
    {
        Task.Factory.StartNew(() =>
        {
            // do the inserts
        });
        return View();
    }
