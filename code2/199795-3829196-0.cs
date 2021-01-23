    var groupedData = from b in dataTable.AsEnumerable()
                      group b by b.Field<string>("chargetag") into g
                      select new
                      {
                          ChargeTag = g.Key,
                          Count = g.Count(),
                          ChargeSum = g.Sum(x => x.Field<int>("charge"))
                      };
