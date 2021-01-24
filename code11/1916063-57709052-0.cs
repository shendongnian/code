    var result = entries.GroupBy(x => new {
           x.Event,
           x.Category
        }).Select(g => new {
           g.Key.Event,
           g.Key.Category,
           Series = g.GroupBy(x => new {x.DateAdded.Month, x.DateAdded.Year})
                     .Select(i => new{
                             i.Key.Month,
                             i.Key.Year,
                             Count = i.Count()
                    }).ToArray()
        });
