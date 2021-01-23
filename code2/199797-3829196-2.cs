    var groupedData = from b in dataTable.AsEnumerable()
                      group b by b.Field<string>("chargetag") into g
                      let list = g.ToList()
                      select new
                      {
                          ChargeTag = g.Key,
                          Count = list.Count,
                          ChargeSum = list.Sum(x => x.Field<int>("charge"))
                      };
