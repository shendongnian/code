    [HttpPost]
    public ActionResult Create(string formatValue)
    {
      using (var dataContext = new YourDbContextModel())
      {
         FormatModel fmtModel = new FormatModel();
         fmtModel.Value = formatValue;
         // rest of your code to save data
      }                   
    }
