    class Program
    {
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>();
            //List seed
            orders = orders.OrderByDescending(x => x.Items.Count(y => y.IsLateForDelivery)).ToList();
        }
    }
    public class Order
    {
        public List<Item> Items { get; set; }
    }
    public class Item
    {
        public bool IsLateForDelivery { get; set; }
    }
