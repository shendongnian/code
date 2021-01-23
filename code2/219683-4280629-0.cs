    private IList<Location> FilterLocation( 
        IList<Location> locations, LocationRequest request) 
    {
        string[] countryList, stateList, cityList;
        if (!string.IsNullOrEmpty(request.Country))
            countryList = request.Country.Split("|");
        if (!string.IsNullOrEmpty(request.State))
            stateList = request.State.Split("|");
        if (!string.IsNullOrEmpty(request.City))
            cityList = request.City.Split("|");
        return locations.Where(lc =>
            (countryList == null || countryList.Any(entry => lc.CountryName.StartsWith(entry,StringComparison.OrdinalIgnoreCase)))
         && (stateList == null || stateList.Any(entry => lc.StateName.StartsWith(entry,StringComparison.OrdinalIgnoreCase)))
         && (cityList == null || cityList.Any(entry => lc.CityName.StartsWith(entry,StringComparison.OrdinalIgnoreCase))))
            .ToList();
    } 
