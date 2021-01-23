    [ChildActionOnly]
    public ActionResult TotalSalesThisMonth()
    {
        var totalSalesModel = SalesService.GetTotalSalesThisMonth()
        return View(totalSalesModel);
    }
