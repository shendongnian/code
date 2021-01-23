    [HttpPost]
    public ActionResult TestData(FormCollection form)
    {
        TestData.Comments = form["Comments"];
        DataContext.InsertTestData(TestData);      
    }
