    [HttpPost]
    public ActionResult MyPostedPage(MyModel model)
    {
        string days = Request.Form.get("WeekDays[]");
        if (days == null) {
            model.WeekDays = 0;  // Depending whether you allow neither day to be selected
                                 // you can handle this differently
        } else {
            model.WeekDays = (WeekDays)Enum.Parse(typeof(WeekDays), days);
        }
      
        ...
     }
