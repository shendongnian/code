    var projectsGroups = dt.AsEnumerable()
                           .GroupBy(r => r.Field<string>("Project"))
                           .Select(pg => new {
                               Project = pg.Key,
                               Clients = pg.GroupBy(r => r.Field<string>("ClientId"))
                                           .Select(cg => new {
                                               ClientId = cg.Key,
                                               UnitCount = cg.Select(r => r.Field<string>("Unit"))
                                                              .Distinct()
                                                              .Count()
                                           })
                           })
                           .ToList();
    
    foreach (var pg in projectsGroups) {
        foreach (var client in pg.Clients) {
            Console.WriteLine($"In Project {pg.Project}, Client {client.ClientId} has {client.UnitCount} unit{(client.UnitCount == 1 ? "" : "s")}");
        }
    }
