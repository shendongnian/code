    var a = ARepository.Get(1);
    var secondPageOfBs = a.BList.AsQueryable()
                                              .OrderBy(c => c.Name)
                                              .Skip(PageSize * 2)
                                              .Take(PageSize)
                                              .ToList();
