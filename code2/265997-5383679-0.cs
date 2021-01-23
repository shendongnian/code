    var items = new[] {item1, item2, item3};
            var result = from s in items.SelectMany((i, index) => i.Subs)
                         group s by s.Name
                         into g
                         select new {
                           Sub = g.Key,
                           Items = items
                              .Where(i => i.Subs.Any(s => s.Name == g.Key))
                              .Select(i => i)
                              .ToList()
                         };
