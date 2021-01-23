    try
        {
            using (System.Transactions.TransactionScope scop = new System.Transactions.TransactionScope())
            {
                using (NorthwindEntities entity = new NorthwindEntities())
                {
                    foreach (Order order in orders)
                    {
                        entity.AddToOrders(order);
                    }
                    entity.SaveChanges();
                }
                scop.Complete();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
