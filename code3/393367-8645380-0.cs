    List<Country> result = (from c in countries
                                    where c.CountryName.StartsWith("C") && c.StateList.Any(s => s.StateName.StartsWith("S"))
                                    select new Country()
                                               {
    
                                                   CountryName = c.CountryName,
                                                   StateList = (from s in c.StateList
                                                                where s.StateName.StartsWith("S")
                                                                select s).Take(3).ToList()
                                               }).ToList();
