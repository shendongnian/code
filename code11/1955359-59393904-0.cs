    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    public class Test
    {
	    public static void Main()
	    {
	    	var products = new List<Product>()
		    {
			    new Product("a", "Clothes"),
			    new Product("b", "Shoes"),
			    new Product("c", "Clothes"),
			    new Product("d", "Clothes"),
    			new Product("e", "Shoes"),
	    		new Product("f", "Shoes"),
		    	new Product("g", "Laptop"),
			    new Product("h", "Laptop"),
			    new Product("h", "Shoes"),
		    };
		    var result = products
			    .GroupBy(p => p.Type)
			    .Select(
			    	group => new 
			    	ProductCount(group.Key, group.Count())
			    	// You can use also an object as the commented code below
			    	//{
    				//	Type = group.Key,
	    			//	Count = group.Count()
		    		//}
			    )
    			.ToList();
	    		
		    Console.WriteLine(ProductCount.ToFormatedString(result));
	    }
	    class Product
	    {
		    public string Name { get; set; }
		    public string Type { get; set; }
    
		    public Product(string name, string type)
		    {
			    this.Name = name;
			    this.Type = type;
		    }
	    }
	    class ProductCount
	    {
		    public string Type { get; set; }
		    public int Count { get; set; }
		
		    public ProductCount(string type, int count)
		    {
			    this.Type = type;
			    this.Count = count;
		    }
		
		    public override string ToString()
		    {
			    return $"\"{this.Type}\" : {this.Count}";
		    }
		
		    public static string ToFormatedString(IEnumerable<ProductCount> products) // if you need a more generic method, u can make this an extension method and use Reflection
																				      // Or u can use a nuget package that formats objects to json (e.g: Newtonsoft is a good library)
		    {
			    var sb = new StringBuilder();
			
			    sb.AppendLine("[{");
			    foreach (var item in products)
				    sb.AppendLine(item.ToString());
			    sb.AppendLine("}]");
			
			    return sb.ToString();
		    }
	    }
    }
