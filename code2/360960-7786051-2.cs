    List<Product> ass = new List<Product>();
    
    Product a = new Product();
    a.KeyWords = "one, two, three";
    
    Product a1 = new Product();
    a1.KeyWords = "one, three";
    
    Product a2 = new Product();
    a2.KeyWords = "five";
    
    ass.Add(a);
    ass.Add(a1);
    ass.Add(a2);
    
    string userInput = "one, seven";
    
    string [] keys = userInput.Split(',');
    var query = new List<Product>();
    foreach (var item in keys)
    {
        query = query.Concat ((IEnumerable<Product>)ass.Where(x=>x.KeyWords.Contains(item))).ToList();
    }
    
    foreach (var item in query )
    {
        Console.WriteLine(item.KeyWords);
    }
