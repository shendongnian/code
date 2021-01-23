    public ActionResult TotalSalesThisMonth()
    {
        var totalSalesModel = SalesService.GetTotalSalesThisMonth()
        if (ControllerContext.IsChildAction)
        {
            return View("foo", totalSalesModel);
        }
        return View("bar", totalSalesModel);
    }
