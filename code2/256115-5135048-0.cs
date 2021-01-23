    var order = (from o in db.Orders.Include("OrderItems.Item")
                 where o.OrderID == id
                 select new OrderViewModel()
                            {
                                Order = o,
                                Items = o.OrderItems.Item    //maybe o.OrderItems.Item.ToList()
                            } ).SingleOrDefault();
