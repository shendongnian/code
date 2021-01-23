    public ActionResult Home()
    {
      IEnumerable<MyDateRecords> myData = LinqQueryToGetAllTheDataUnFiltered();
      ViewData.Model = new MyViewData { MyData = myData; }
      return View();
    }
