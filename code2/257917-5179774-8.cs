    var results = from res in dt.AsEnumerable()
                      group res by res.Field<string>(key)
                          into grp
                          orderby Convert.ToInt32(grp.Key)
                          select new
                          {
                              date = grp.Key,
                              sum = grp.Average(r => Convert.ToDouble(r.Field<string>(average))),
                              stdDev =  gp.Select(s => Convert.ToDouble(s.Field<string>(average))).StdDev(),
                              // alternative override - note no need to convert
                              stdDev2 = gp.StdDev(s => s.Field<string>(average))
                          };
