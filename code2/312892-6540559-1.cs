    var people = new[] { 
        new { Name = "Adam", Role = "R1" },
        new { Name = "Adam", Role = "R2" },
        new { Name = "Adam", Role = "R3" },
        new { Name = "Bob", Role = "R1" },
    };
    var r = from p in people
            group p by p.Name
            into g
            select new {
                Name = g.Key,
                Roles = g.Select(p => p.Role).ToList()
            };
    var d = r.ToDictionary(k => k.Name, e => e.Roles);
