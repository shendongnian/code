    [AjaxOnly]
    [HttpPost]
    public ActionResult LeftColumnData()
    {
        var Column= new ColumnViewModel { Attempt= DateTime.Now };
        return PartialView("_LeftColumn", Column);
    }
