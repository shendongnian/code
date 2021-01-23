    public Action SaveIntoTempData()
    {
      ...
      TempData["TempData"] = "Something to be stored ONE request ONLY";
      ...
    }
    
    public Action ReadFromTempData()
    {
       ...
       string tempData = (string)TempData["TempData"];
    }
