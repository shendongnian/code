var newCities = response.Data.Where(i =>i.Cities != null)
                                         .SelectMany(x => x.Cities)
                                         .Select(a => new
                                            {
                                                CountryId = a.Id,
                                                CountryName = a.Name,
                                                Cities = a.Districts
                                            }).ToList();
