    public IEnumerable<CustomOrder> CustomOrders
    {
        get
        {
            return base.Orders
                .Where(o => o.GetType() == typeof(CustomOrder))
                .Select(o => o as CustomOrder);
        }
    }
