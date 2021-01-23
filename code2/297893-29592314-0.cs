	public class Product
	{
		public string Name {get; set;}
		public DateTime Expiry {get; set;}
		public string[] Sizes {get; set;}
	}
	
	public void Main()
    {
		Product product = new Product();
		product.Name = "Apple";
		product.Expiry = new DateTime(2008, 12, 28);
		product.Sizes = new string[] { "Small" };
		
		string json = JsonConvert.SerializeObject(product, Formatting.None);
		Console.WriteLine(json);
		json = JsonConvert.SerializeObject(product, Formatting.Indented);
		Console.WriteLine(json);
    }
