    public static List<string> GetCitiesInCountryWithState(string isoalpha2)    
    {
        const string delimiter = ", ";        
        using (var ctx = new atomicEntities())        
        {
            var query = from c in ctx.Cities                        
                        join ctry in ctx.Countries on c.CountryId equals ctry.CountryId 
                        where ctry.IsoAlpha2 == isoalpha2                        
                        select c.CityName + delimiter + c.State ;            
            return query.ToList();
        }
    }
