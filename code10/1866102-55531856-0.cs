    class Program
    {
        public class Order
        {
            public Order(int id, string time)
            {
                this.Id = id;
                this.Time = time;
            }
    
            public int Id { get; set; }
            public string Time { get; set; }
        }
    
        static void Main(string[] args)
        {
            List<Order> list = new List<Order>();
            list.Add(new Order(0, "1"));
            list.Add(new Order(1, "2"));
            list.Add(new Order(2, "1"));
            list.Add(new Order(3, "2"));
            list.Add(new Order(4, "1"));
    
    
            IQueryable<Order> test = GetOrderFiltered(list.AsQueryable(), new Order(121, "1"));
            // test has orders 0,2,4
        }
    
        public static IQueryable<Order> GetOrderFiltered(IQueryable<Order> OrdersQuery, Order order)
        {
            return OrdersQuery.Where(x => x.Time == order.Time);
        }
    }
