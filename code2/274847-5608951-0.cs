    public List<CustOrder> GetOrders(string supplierId, string locationId)
    {
        using (var ctx = new OrderEntities())
        {
            var query = from order in ctx.CustOrder
                        where order.SupplierId == supplierId
                        select order;
            
            if (!string.IsNullOrEmpty(locationId))
            {
                query = query.Where(o => o.LocationId == locationId)
            }
            
            return query.ToList();
        }
    }
