    var newcountry = new Country
                     {
                         CountryCode = "VE",
                         CountryName = "VENEZUELA"
                     };
    bool country = ListBoxCountries.Items.Cast<Country>().FirstOrDefault(c=>c.CountryCode == newcountry.CountryCode && c.CountryName == newcountry.CountryName)
    if(country == null)
      countries.Add(newcountry);
