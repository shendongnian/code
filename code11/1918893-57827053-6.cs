    public void fillCountry()
    {
      //Fills the list with the countries in the database
      List<Country> countryList = countryService.getCountries();
    
      var dataSource = countryList.Select(c=> new { DataValueField = 
      c.countryID + "~" + c.countryAbbreviature, DataTextField = c.countryDesc }).ToList();
    
      ddlCountry.DataSource = dataSource;
      ddlCountry.DataTextField = "DataTextField";
      ddlCountry.DataValueField = "DataValueField";
    
      ddlCountry.DataBind();
    }
