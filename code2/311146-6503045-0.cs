            var query = db.Leagues
                          .Where(l => l.URLPart.Equals(leagueName))
                          .Select(l => new 
                              {
                                  League = l,
                                  Events = l.LeagueEvents.Where(...)
                                                         .OrderBy(...)
                                                         .Take(3)
                                                         .Select(e => e.Event)
                                  ... 
                              });
