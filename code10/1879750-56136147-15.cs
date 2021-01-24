    public partial class ObeyOrder : IObeyOrder
    {
        private static readonly Dictionary<string, int[]> orderedMethods = OrderHelper<IObeyOrder>.OrderedMethods;
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
