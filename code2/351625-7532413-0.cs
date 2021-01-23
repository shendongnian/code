    IEnumerable<Country> sortedCountries = countries.OrderBy(
                    c => LocalizationUtility.GetResourceString(c.ResourceKeyName));
    
    foreach (Country country in sortedCountries)
    {
        string name = LocalizationUtility.GetResourceString(country.ResourceKeyName);
        if (!string.IsNullOrEmpty(name))
        {
            ListItem item = new ListItem(name);
            item.Attributes.Add(
                 "PrivacyOption", 
                 Convert.ToString(country.PrivacyOption));
            drpCountryRegion.Items.Add(item);
        }
    }
