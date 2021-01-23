    return siebelRows.GroupBy(sr => new
                              { 
                                  AreaCode = sr.Field("AreaCode")
                                               .Substring(0, 3),
                                  Contact = sr.Field("Contact")
                              })
                     .Select(kvp => new Customer
                                    {
                                        Id = Guid.NewGuid(),
                                        AreaCode = kvp.Key.AreaCode,
                                        CustAccount = kvp.Key.Contact,
                                        // rest of the assignment
                                    }
                     .Take(5);
