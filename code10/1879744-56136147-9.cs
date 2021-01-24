    public partial class ObeyOrder : IObeyOrder
    {
        private static readonly Dictionary<string, int[]> orderedMethods =
            typeof(IObeyOrder)
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
        private readonly Queue<int> orders = new Queue<int>(orderedMethods.Values.SelectMany(i => i).OrderBy(i => i));
        private void CheckOrder([CallerMemberName] string methodName = "")
        {
            if (!orderedMethods.TryGetValue(methodName, out var methodOrders))
                return;
            var order = orders.Peek();
            if (!methodOrders.Contains(order))
                throw new Exception($"Wrong method call order. Method '{methodName}' with orders [{string.Join(", ", methodOrders)}]. Expected order {order}.");
            orders.Enqueue(orders.Dequeue());
        }
    }
