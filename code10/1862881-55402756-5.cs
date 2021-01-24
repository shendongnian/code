    List<Product> products = new List<Product>();
    bool ok = true;
    while(ok)
    {
        string input;
        Product p = new Product();
        ok = getInput("Item Name(enter 0 to stop): ", out input);
        if (ok) p.Name = input;
        if (ok) ok = getInput("Item Price(enter 0 to stop): ", out input);
        if (ok) p.Price = Convert.ToDecimal(input);
        if (ok) ok = getInput("Quantity(enter 0 to stop): ", out input);
        if (ok) { p.Quantity = Convert.ToInt32(input); products.Add(p);}
    }
    decimal totalPrice = products.Sum(p => p.Price);
    Console.WriteLine(totalPrice);
