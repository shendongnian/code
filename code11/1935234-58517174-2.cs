    var aggList = items.GroupBy(u => new { u.ID, u.TimeStamp.Date, u.TimeStamp.Hour })
                                .Select(g => new TestData
                                {
                                    ID = g.Key.ID,
                                    TimeStamp = g.Key.Date.AddHours(g.Key.Hour),
                                    Value = g.Sum(k => k.Value)
                                }).ToList();
