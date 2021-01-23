    public List<SelectListItem> YesNoList
    {
      get
      {
        List<SelectListItem> YesNoList = new List<SelectListItem>();
        YesNoList.Add(new SelectListItem {Text = "", Value = ""});
        YesNoList.Add(new SelectListItem {Text = "Yes", Value = "1"});
        YesNoList.Add(new SelectListItem {Text = "No", Value = "0"});
      }
      private set{}
     }
