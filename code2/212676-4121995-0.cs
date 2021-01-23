    var cultureInfo = new DateTimeFormatInfo();
    var dayNames = new[] 
    {
        DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, 
        DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, 
        DayOfWeek.Sunday 
    }.Select(cultureInfo.GetDayName);
    var newitems = dayNames
        .Select((dayName, index) => new SelectListItem
        {
            Value =(index).ToString(),
            Text = dayName,
            Selected = (selectedValue == dayName)
        });
    var result = helper.DropDownList(id, newitems).ToHtmlString();
    return result;
