    var output = from mt in MemberTanks
                 group by {mt.Tier, mt.Class, mt.TankName} into g
                 select new { g.Key.Tier, 
                              g.Key.Class, 
                              g.Key.TankName, 
                              Fights = g.Sum(mt => mt.Battles), 
                              Wins = g.Sum(mt=> mt.Victories
                            };
