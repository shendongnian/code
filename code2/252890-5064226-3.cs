    var counts = from artist in qCategory
                 group artist by artist.Subcategory into g
                 select new {
                               Category = g.Select(a => a.Category)
                                           .Distinct()
                                           .Single(),
                               Subcategory = g.Key,
                               Count = g.Count()
                            };
