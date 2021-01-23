    var groupedData = from b in dataTable.AsEnumerable()
                      group b by b.Field<string>("chargetag") into g
                      select new
                      {
                          ChargeTag = g.Key,
                          List = g.ToList(),
                      } into g
                      select new 
                      {
                          g.ChargeTag,
                          Count = g.List.Count,
                          ChargeSum = g.List.Sum(x => x.Field<int>("charge"))
                      };
