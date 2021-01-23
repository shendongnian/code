     public List<CustOrder> GetOrders(string supplierId, string locationId)
     {
            using (var ctx = new OrderEntities())
            {
                 var result = (from order in ctx.CustOrder
                                      where order.SupplierId == supplierId
                                         && ((String.IsNullOrEmpty(locationId) && order.LocationId == locationId) || 
                                             order.LocationId.Length > 0)
                                      select order).ToList();
                 return result;
           }
     }
