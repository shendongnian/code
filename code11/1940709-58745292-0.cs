    using (var context = new BbsfDbContext())
    {
        var sapOrders = ...;
        var ordersCreated = new List<..>(); // might wanna initialized this with a size if you have a rough gauge on what % will need creation of loop
        //if (sapOrders.Any()) // not needed
        //{
            foreach (var item in sapOrders.Select((x, index) => new { x, index }))
            {
                try
                {
                    var order = ...;
                    var isExist = ...;
                    if (isExist)
                    {
                        // ...
                        if (order == null)
                        {
                            order = new Order { ... };
                                var savedOrder = context.Orders.Add(order);
                                //context.SaveChanges();
                                //order.SASNo = BbsfConsts.KeasOrderNumberPrefix + savedOrder.Id;
                                ordersCreated.Add(order);
                            }
                            else
                            {
                                // Do updates
                                // ...
                            }
                        }
                        else
                        {
                            //if (order != null) // shouldn't need this
                            //{
                                var orderDetails = context.OrderDetails.Where(p => p.OrderId == order.Id).ToList();
                                orderDetails?.ForEach(p => context.OrderDetails.Remove(p));
                                //context.SaveChanges();
                                context.Orders.Remove(order);
                                //context.SaveChanges();
                            //}
                        }
                        // ...
                        if (index % 1000 == 0)
                        {
                            context.BulkSaveChanges(); // bulk save of 1000 loops of changes
                            
                            foreach (var orderCreated in ordersCreated)
                            {
                                orderCreated.SASNo = BbsfConsts.KeasOrderNumberPrefix + savedOrder.Id;
                            }
                            context.BulkSaveChanges(); // bulk save of x num of SASNo sets
                        }
                    }
                    catch (Exception ex)
                    {
                        // ...
                    }
                }
            }
        }
    }
