    var groupedLists = peopleList.GroupBy(person => person.Type)
                                 .OrderBy(group => group.Key)
                                 .Select(group => new {
                                     People = group.ToList(),
                                     AverageScore = group.Average(p => p.ScorePercent)
                                  })
                                  .ToList();
