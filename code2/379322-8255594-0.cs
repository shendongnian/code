    public void Linq49() 
    { 
        List<Product> products = GetProductList(); 
        List<Customer> customers = GetCustomerList(); 
      
        var productFirstChars = 
            from p in products 
            select p.ProductName[0]; 
        var customerFirstChars = 
            from c in customers 
            select c.CompanyName[0]; 
      
        var uniqueFirstChars = productFirstChars.Union(customerFirstChars); 
      
        Console.WriteLine("Unique first letters from Product names and Customer names:"); 
        foreach (var ch in uniqueFirstChars) 
        { 
            Console.WriteLine(ch); 
        } 
    }
