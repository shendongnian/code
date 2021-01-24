var joinedRegionAndCountry = repository.Regions
                               .Join(repository.Countries, 
                                     r => r.System_A_Name == "North America_A", 
                                     c => c.System_B_Name == "Canada", 
                                    (r, c) => new { Region = r, Country = c})
                             .Count();
