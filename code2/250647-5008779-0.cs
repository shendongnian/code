    // Return days of the month for a dropdownlist
    public static class SelectListHelper
    {
        public static SelectList DayList()
        {
            return NumberList(1, 31);
        }
    }
    
    // Use in view 
    @Html.DropDownListFor(m => m.Day, SelectListHelper.DayList())
