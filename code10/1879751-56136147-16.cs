    public static class OrderHelper<T>
    {
        public static Dictionary<string, int[]> OrderedMethods { get; } = typeof(T)
            .GetMethods()
            .Select(method => new
            {
                Method = method.Name,
                Orders = method.GetCustomAttributes(typeof(OrderAttribute), false)
                               .Cast<OrderAttribute>()
                               .Select(attribute => attribute.Order)
                               .ToArray()
            })
            .Where(method => method.Orders.Length > 0)
            .ToDictionary(method => method.Method, method => method.Orders);
    }
