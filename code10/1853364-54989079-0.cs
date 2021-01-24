    [HttpGet]
    public ActionResult TesMethod (int employeeID, int? testID = null)
    {
        Excel excel = new Excel();
        excel.CreateExport(testID, int employeeID);
        return RedirectToAction("Index", "Employee");
    }
