var joined = repository.Regions
                   .Join(repository.Countries, 
                         r => r.Id, //common attribute to base join
                         c => c.Id, //common attribute to base join
                        (r, c) => new { Region = r, Country = c}) //selector for your joined statmenet
//your conditions
                   .Where(joinedRegAndCountry => 
                              joinedRegAndCountry.Region.System_A_Name == "North America_A",
                              joinedRegAndCountry.Country.c.System_B_Name == "Canada")
                             .Count();
