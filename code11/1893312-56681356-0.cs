    [HttpPost]
    public ActionResult CheckProductCost(ProductModel model)
    {
        ModelState.Clear();
        using (var db = DataContext.Db)
        {
            model.IsCostUpdated = model.CheckUpdate(db);
        }
        if (Request.IsAjaxRequest()) // THIS IS AVAILABLE INSIDE THE SYSTEM.WEB.MVC ASSEMBLY
            return Json(new { IsCostUpdated = model.IsCostUpdated });
        return PartialView("ProductDataTable", model);
    }
