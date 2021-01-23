    public static MvcHtmlString ComboDaysOfWeekNumber(this HtmlHelper helper, 
                                  string id, int selectedValue)
    {
        var dayNames = new[]
                           {
                               DayOfWeek.Monday, DayOfWeek.Tuesday, 
                               DayOfWeek.Wednesday, DayOfWeek.Thursday, 
                               DayOfWeek.Friday, DayOfWeek.Saturday,
                               DayOfWeek.Sunday
                           };
        var newitems = dayNames
            .Select((dayName, index) => new SelectListItem
            {
                Value =(index).ToString(),
                Text = dayName.ToString(),
                Selected = (selectedValue == index)
            });
        var result = helper.DropDownList(id, newitems);
        return result;
    }
