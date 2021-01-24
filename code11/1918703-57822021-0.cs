    static SortedDictionary<string, int> GetProducts()
	{
        //                               Type of the
        //                                   key     
        //                                    |  Type of the
        //                                    |    value
        //                                    |      |
        //                                    v      v
		var Products = new SortedDictionary<string, int>();
		
		while (true)
		{
			var product = "";
			int quantity;
            // First, ask the user to enter a product. If he enters nothing, ask again
			while (product == "")
			{
				Console.WriteLine("Please enter a product name or f to finish");
				product = Console.ReadLine();
				if (product == "f")
					return Products; // we are done, we can return the SortedDictionary
			}
            // Now, get the quantity
			do
			{
				Console.WriteLine($"Please enter a quantity for {product}");
              // Ask again if the user enters an invalid number
			} while (!Int32.TryParse(Console.ReadLine(), out quantity));
            // Store the informations in the SortedDictionary
			Products[product] = quantity;
		}
	}
	
	public static void Main()
	{
        // Get the products
		var Products = GetProducts();
        // Display them
		foreach (var key in Products.Keys)
			Console.WriteLine($"{Products[key]}x {key}");
	}
