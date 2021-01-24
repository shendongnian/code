    var changes = from ord in resultSet
                           group ord by new
                           {
                              ord.Option,
                              ord.Year,
                           }
                           into g
                           select new
                           {
                              Option = g.Key.Option,
                              Year = g.Key.Year,
                              ChangedCount = g.Select(x => x.Value).Sum()
                           };
