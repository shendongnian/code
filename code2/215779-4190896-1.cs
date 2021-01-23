    public IEnumerable<SelectListItem> CountryList
    {
        get
        {
            return GetCountryList().Select(
                t => new SelectListItem { Text = t.Name, Value = Convert.ToString(t.CountryID) });
        }
    }
