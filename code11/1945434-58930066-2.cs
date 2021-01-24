    var aggList = items.GroupBy(u => new { u.ID, u.TimeStamp.AddMinutes(-15).Date, u.TimeStamp.AddMinutes(-15).Hour })
                                .Select(g => new TestData
                                {
                                    ID = g.Key.ID,
                                    TimeStamp = g.Key.Date.AddHours(g.Key.Hour),
                                    Value = g.Sum(k => k.Value)
                                }).ToList();
