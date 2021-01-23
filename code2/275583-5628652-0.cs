    public static List<City> GetCitiesInCountryWithState(string isoalpha2)
    {
        const string delimiter = ", ";
        using (var ctx = new atomicEntities())
        {
            var query = (from c in ctx.Cities
                        join ctry in ctx.Countries on c.CountryId equals ctry.CountryId
                        where ctry.IsoAlpha2 == isoalpha2
                        select new City
                                   {
                                       CityId = c.CountryId,
                                       CityName = c.CityName + delimiter + c.State
                                   }).ToList();
            return query;
        }
    }
    var cityList = GetCitiesInCountryWithState(Session["BusinessCountry"].ToString());
    ddlCity.DataSource = cityList;
    ddlCity.DataTextField = "CityName";
    ddlCity.DataValueField = "CityId";
    ddlCity.DataBind();
