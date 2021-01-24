    public IActionResult MyControllerMethod()
    {
      using (var db = new ConnectionStringName())
      {      
        foreach (var item in Model.TotalNumberProxy.LstFByTAndB)
        {
          LstFByTAndB.VType = @db.code_VType.Find(item.Key).VType;
        }
      }
      for (var i = 1; i <= 12; i++)
      {
        item.Columns.Add(item.Count(x => x.tblFAM.CDate.Month == i));
      }      
      return View(model);
    }
