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
    // Another one for selecting genders
    public static SelectList GenderList(string selectedValue = null)
    {
        IList<KeyValuePair<string, string>> genders = new List<KeyValuePair<string, string>>();
        genders.Insert(0, new KeyValuePair<string, string>("F", "Female"));
        genders.Insert(0, new KeyValuePair<string, string>("M", "Male"));
        genders.Insert(0, new KeyValuePair<string, string>("", "Choose Gender"));
        return new SelectList(genders, "Key", "Value", selectedValue);
    }
    // Use in my edit view
    @Html.DropDownListFor(m => m.Gender, SelectListHelper.GenderList())
