    var ordersInList1 = list1.GroupBy(order => order.CustomerId)
                             .ToDictionary(g => g.Key, g => g.Count());
    var ordersInList2 = list2.GroupBy(order => order.CustomerId)
                             .ToDictionary(g => g.Key, g => g.Count());
    var results = ordersInList1.Keys.Union(ordersInList2.Keys)
                               .Select(id =>
                               new { 
                                    CustomerId = id, 
                                    CountOrders1 = ordersInList1[id], 
                                    CountOrders2 = ordersInList2[id]
                               })
                               .ToArray();
