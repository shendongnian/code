    var qry = dList.GroupBy(x => x["CustID"]).Select(g => new Customer
            {
                ID = g.Key.ToString(),
                Name = g.First()["Name"],
                OrderList=g.Select(o => new List<Order>(new Order{ OrderNumber=o["OrderNumber"]}))
            }).ToList();
