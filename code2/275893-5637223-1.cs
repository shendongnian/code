    [HttpPost]
    public ActionResult RunQuery(string column1, string column2)
    {
        var results = GetDataFromDatabase(column1, column2);
        return View(results ); 
    }
