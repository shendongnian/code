    var result = memberTanks.GroupBy(x => new {x.Tier, x.Class, x.TankName})
                            .Select(g => new { g.Key.Tier, 
                              g.Key.Class, 
                              g.Key.TankName, 
                              Fights = g.Sum(mt => mt.Battles), 
                              Wins = g.Sum(mt=> mt.Victories)
                            });
