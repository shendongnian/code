    var result = queryable
        .GroupBy(r => r.Name)
        .Select(grp => new
        {
            Name = grp.First().Name,
            Cities = grp.Count(x => x.CityId != null),
            Users = grp.Count(x => x.UserId != null)
        }).ToList();
