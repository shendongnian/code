    void Main()
    {
      DataContext db = new DataContext(@"server=.\SQLexpress;trusted_connection=yes;database=Northwind");
      Table<Customer> Customers = db.GetTable<Customer>();
    
      
      var data = Customers.Where(c => c.Country == "USA");
      foreach (var customer in data)
    {
    		Console.WriteLine($"{customer.CustomerID}, {customer.CompanyName}");
    }
    }
    
    [Table(Name = "Customers")]
    public class Customer
    {
        [Column]
    	public string CustomerID { get; set; }
    	[Column]
    	public string CompanyName { get; set; }
    	[Column]
    	public string ContactName { get; set; }
    	[Column]
    	public string Country { get; set; }
    }
