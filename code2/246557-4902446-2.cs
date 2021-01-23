    public ActionResult details(int id)
    {
       Order viewModel = storeDb.Orders.Single(o => o.Id = id);
       return View(viewModel);
    }
