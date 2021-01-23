            var sumVictories = (from p in memberTanks
                                group p by p.TankName
                                into g
                                select new
                                        {
                                            Tank = g.Key,
                                            Victories = g.Sum(p => p.Victories),
                                            Avg = ((double)g.Sum(p => p.Victories) / (double)g.Sum(p => p.Battles)) * 100
                                        }).OrderByDescending(a => a.Victories);
