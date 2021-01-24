    string defaultConString = @"server=.\SQLExpress2012;Database=Northwind;Trusted_Connection=yes;";
    
    void Main()
    {
    	var ctx = new MyContext(defaultConString);
    	var customerId = "FISSA";
    
    	var customer = ctx.Customers
    		.Include(c => c.Orders)
    		.SingleOrDefault(c => c.CustomerId == customerId);
    
    	if (customer != null)
    	{
    		Console.WriteLine($"{customer.CompanyName}, Orders: {customer.Orders.Count()}");
    		//		var frmMusteriSiparisleri = new Form { Text = string.Format("[{0}] - Siparisler", customerId) };
    		//		var dgvSiparisler = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, DataSource = customer.Orders.ToList() };
    		//		frmMusteriSiparisleri.Controls.Add(dgvSiparisler);
    		//		frmMusteriSiparisleri.ShowDialog();
    	}
    }
    
    
    public class MyContext : DbContext
    {
    	public MyContext(string connectionString)
    	   : base(connectionString)
    	{ }
    	public DbSet<Customer> Customers { get; set; }
    	public DbSet<Order> Orders { get; set; }
    	public DbSet<OrderDetail> OrderDetails { get; set; }
    	public DbSet<Product> Products { get; set; }
    }
    
    
    
    public class Customer
    {
    	[Key]
    	public string CustomerId { get; set; }
    	public string CompanyName { get; set; }
    	public string ContactName { get; set; }
    	// ...
    	public virtual List<Order> Orders { get; set; }
    }
    
    public class Order
    {
    	[Key]
    	public int OrderId { get; set; }
    	public string CustomerId { get; set; }
    	public DateTime OrderDate { get; set; }
    	public DateTime? ShippedDate { get; set; }
    	[ForeignKey("CustomerId")]
    	public Customer Customer { get; set; }
    	public virtual List<OrderDetail> OrderDetails { get; set; }
    }
    
    [Table("Order Details")]
    public class OrderDetail
    {
    	[Key]
    	[Column(Order = 1)]
    	public int OrderId { get; set; }
    	[Key]
    	[Column(Order = 2)]
    	public int ProductId { get; set; }
    	public decimal UnitPrice { get; set; }
    	public Int16 Quantity { get; set; }
    	[ForeignKey("ProductId")]
    	public Product Product { get; set; }
    	[ForeignKey("OrderId")]
    	public Order Order { get; set; }
    }
    
    public class Product
    {
    	public int ProductId { get; set; }
    	public string ProductName { get; set; }
    	// ...
    }
