    class Program
    {
        static void Main(string[] args)
        {
            dynamic order = new BusOrder();
            Console.WriteLine(order.Test);
            Console.ReadLine();
        }
    }
    class BusOrder : DynamicObject
    {
        private Order _order = new Order();
        
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = _order.GetType().GetProperty(binder.Name).GetValue(_order, null);
            return true;
        }
    }
