    string input = "Product,Price,Condition\r\nCd,13,New\r\nBook,9,Used";
    
    string[] deconstructedInput = input.Split(new string[] { "\r\n", "," }, StringSplitOptions.None);
    
    List<Product> products = new List<Product>();
    for (int i = 3; i < deconstructedInput.Length; i += 3)
    {
    	products.Add(new Product
    	{
    		Name = deconstructedInput[i],
    		Price = Decimal.Parse(deconstructedInput[i + 1]),
    		Condition = deconstructedInput[i + 2]
    	});
    }
    public class Product
    {
    	public string Name { get; set; }
    	
    	public decimal Price { get; set; }
    	
    	public string Condition { get; set; }
    }
