       var groupByTest = result.
                GroupBy(g => new
                {
                    First = g.Field1
                }).
                Select(gp => new
                {
                    gp.Key.Field1,
                    InnerList = gp.ToList()
                }).ToList();
