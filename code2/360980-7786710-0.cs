    var matches = cities.Where(c => c.CityName.Contains(substr))
                        .Select(a => String.Format("{0} {1} {2}",
                                            a.CityName, 
                                            a.State.StateName, 
                                            a.State.Country.CountryName 
                               ));
