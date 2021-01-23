     public List<CustOrder> GetOrders(string supplierId, string locationId)
     {
            using (var ctx = new OrderEntities())
            {
                 var result = (from order in ctx.CustOrder
                                      where order.SupplierId == supplierId
                                         && order.LocationId == locationId ?? string.Empty
                                      select order).ToList();
                 return result;
           }
     }
