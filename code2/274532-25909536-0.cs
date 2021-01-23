    var groupedData = from b in yourDataTable.AsEnumerable().Where(r=>r.Field<int>("FILTER_ROWS_FIELD").Equals(9999))
                              group b by b.Field<string>("A_GROUP_BY_FIELD") into g
                              select new
                              {
                                  tag = g.Key,
                                  count = g.Count(),
                                  sum = g.Sum(c => c.Field<double>("rvMoney"))
                              };
