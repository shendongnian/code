    public PartialViewResult LeftColumnData()
    {
        var Column = new ColumnViewModel { Attempt = DateTime.Now };
        return PartialView("_LeftColumn", Column);
    }
