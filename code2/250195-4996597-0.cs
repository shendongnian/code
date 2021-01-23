    public static IQueryable<Order> GetOrders(int orderNumber, int? productAreaId, OSDataContext db)
    {
        var orders = db.Orders.Where(o => o.OrderNumber == orderNumber &&
            o.Group.GroupTypeId != (int)GroupTypeId.INTERNAL &&
            !o.Deleted);
    
    
        if (productAreaId != null)
        {
            var orders2 = orders.Where(o => o.ProductAreaId == productAreaId);
    return orders2.Select(x => new {x, Type = 2 }).Concat(orders.Select(x => new {x, Type = 1 })).OrderBy(x => x.Type);
        }
        return orders;
    }
