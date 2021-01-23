    public IEnumerable<CustomOrder> CustomOrders
    {
        get
        {
            return base.Orders
                // We check the BaseType here because EF creates a derived class of our classes. 
                .Where(o => o.GetType().BaseType == typeof(CustomOrder))
                .Select(o => o as CustomOrder);
        }
    }
