    [HttpGet]
    public ActionResult TesMethod (int employeeID, int? testID = null)
    {
        Excel excel = new Excel();
        excel.CreateExport(testID, employeeID);
        return RedirectToAction("Index", "Employee");
    }
