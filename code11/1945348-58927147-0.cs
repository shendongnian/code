    public static void Main()
    {
        ShowData(AddData());
    }
    public static void ShowData(Guid orderId)
    {
        using var context = new OrderContext();
        Console.WriteLine(context.Orders
            .Where(x => x.Id == orderId)
            .First()
            .ToString());
    }
    public static Guid AddData()
    {
        using var context = new OrderContext();
        var status = new Status()
        {
            StatusName = "approved"
        };
        var order = new Order()
        {
            Description = "Description",
            Name = "Name",
            OrderStatus = status
        };
        context.Orders.Add(order);
        context.SaveChanges();
        return order.Id;
    }
    public class Status
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
        public override string ToString()
        {
            return $"{StatusName}";
        }
    }
    public class Order
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Status OrderStatus { get; set; }
        public override string ToString()
        {
            return $"{Id} {Description} {OrderStatus}";
        }
    }
