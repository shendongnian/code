     var result = originalCollection.GroupBy(x=>x.Team)
                                    .SelectMany(x=>x.Select(c=>new 
                                                           {
                                                            c.Team,
                                                            c.MinSecondsPerGame,
                                                            TeamMins=x.Sum(v=>v.MinSecondsPerGame
                                                           )})).ToList();
