    List<Temp> list = table.AsEnumerable()
                 .Where(p => p.Field<string>("Customer_Code") == "1001")
                 .Select(p => new Temp()
                               {
                                  Location = p.Field<string>("Location"),
                                  Country = p.Field<string>("Country")
                               })
                 .Distinct().ToList();
