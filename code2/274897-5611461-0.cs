    public static List<string> GetCitiesInCountryWithState(string isoalpha2)
    {
        using (var context= new atomicEntities())
        {
            return (from city in context.Cities
                    join country in context.Countries on c.CountryId equals country.CountryId
                    where country.IsoAlpha2 == isoalpha2
                    select String.Concat(city.CityName, ", ", city.State)
                    // select String.Format("{0}, {1}", city.CityName, city.State)
                    ).ToList();             
        }
    }
