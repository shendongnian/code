csharp
    var result = employeeCollection.AsQueryable()
                   .GroupBy(e => e.cityId)
                   .Select(g => new { employeeCount = g.Count(), cityId = g.Key })
                   .Join(cityCollection.AsQueryable(),
                         x => x.cityId,
                         c => c.CityId,
                         (x, c) => new { x.employeeCount, c.CityName })
                   .ToList();
test program:
