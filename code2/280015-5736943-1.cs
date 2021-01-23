    var qry = dList.GroupBy(x => new { CustID = (string) x["CustID"],
                                       Name = (string) x["Name"] })
                   .Select(g => new Customer {
                              ID = g.Key.CustID,
                              Name = g.Key.Name,
                              OrderList = g.Select(x => new Order {
                                     // Indentation bad to avoid scrolling!
                                     OrderNumber = (string) x["OrderNumber"] })
                                           .ToList()
                           })
                   .ToList();
