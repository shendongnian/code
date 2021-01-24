    var playersGroupList = orderedResults.GroupBy(x => new { x.SessionDate, x.GameId })
                                         .SelectMany(g => g.GroupByPairsWhile((p, c) => c.SessionStartTime-p.SessionEndTime <= TimeSpan.FromMinutes(35)))
                                         .Select(group => new GroupedEvents {
                                             GameName = group.Select(n => n.SessionGameName).FirstOrDefault(),
                                             GameId = group.Select(c => c.GameId).FirstOrDefault().ToString(),
                                             PlayDate = group.Select(d => d.SessionDate).FirstOrDefault(),
                                             Names = String.Join("; ", group.Select(g => g.SessionEventName).ToArray()),
                                             PlayDuration = group.Select(g => g.SessionStartTime).First() + " - " + group.Select(g => g.SessionEndTime).Last(),
                                         })
                                         .ToList();
