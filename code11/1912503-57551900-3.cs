    var country = "UK";
    var result = worldEventList.Where(x => x.PresentationList.Any(y => y.Country == country))
                               .Select(x => new WorldEvent()
                                   {
                                      ID = x.ID,
                                      Name = x.Name,
                                      PresentationList = x.PresentationList.Where(y => y.Country == country)
                                                          .ToList()
                                    }).ToList();
