    public Action SaveIntoViewData()
    {
      ...
      TempData["ViewData"] = "Something to be stored into the page";
      ...
    }
    
    public Action ReadFromViewData()
    {
       ...
       string viewData = (string)ViewData["ViewData"];
    }
