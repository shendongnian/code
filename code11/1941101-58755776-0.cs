	public class Customer
	{
		public int id { get; set; }
		public string name { get; set; }
	}
	public class Product
	{
		public int id { get; set; }
		public string description { get; set; }
		public double price { get; set; }
	}
	public class RootObject
	{
		public List<Customer> customers { get; set; }
		public List<Product> products { get; set; }
	}
