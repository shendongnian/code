    var groupedList = joinedList.GroupBy(grp => new {
                                 grp.Id,
                                 grp.Name,
                                 grp.Width,
                                 grp.Type,
                                 grp.GSM
    }).Select(grp => new {
                                 grp.Key.Id,
                                 grp.Key.Name,
                                 grp.Key.Width,
                                 grp.Key.Type,
                                 grp.Key.GSM,
                                 SumOfWeight = grp.Sum(w => w.Weight)
    }).ToList();
