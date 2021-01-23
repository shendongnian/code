    void Main()
    {
    	var customers = new List<Customer> {new Customer() { CustomerId = 1}, new Customer() { CustomerId = 2}};
    	var orders = new List<Order> {new Order() { OrderId = 1, CustomerId = 1}, new Order() { OrderId = 2, CustomerId = 1}};
    	var items = new List<Item> {new Item() { ItemId = 1, OrderId = 1}, new Item() { ItemId = 2, OrderId = 1}, new Item() { ItemId = 3, OrderId = 2}};
    	
    	var doubleJoin = from customer in customers
     	join order in orders on customer.CustomerId equals order.CustomerId
    	into customerOrders
    	from co in customerOrders.DefaultIfEmpty()
    	where (co != null)
    	join item in items on co.OrderId equals item.OrderId
    	select new {Customer = customer, Orders = co,  Items = item};
    	
    	doubleJoin.Dump();
    }
    
    public class Customer
    {
    	public int CustomerId { get; set; }
    }
    
    public class Order
    {
    	public int OrderId { get; set; }
    	public int CustomerId { get; set;}
    }
    
    public class Item
    {
    	public int ItemId { get; set; }
    	public int OrderId { get; set; }
    }
