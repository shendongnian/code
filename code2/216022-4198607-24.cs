    [HttpPost]
    public ActionResult MyPostedPage(MyModel model)
    {
      //I moved the logic for setting this into a helper because this could be re-used elsewhere.
      model.WeekDays = Enum<DayOfWeek>.ParseToEnumFlag(Request.Form, "WeekDays[]");
      ...
    }
