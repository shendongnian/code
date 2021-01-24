    List<string> Customers = new List<string>();
    Customers.Add("Faizan");
    Customers.Add("Ali");
    Customers.Add("Fazeel");
    Customers.Add("Salim");
    Customers.Add("Mueen");
    Customers.Add("Haleem");
    Customers.Add("Mazin");
    
    Console.WriteLine(String.Join(Environment.NewLine, Customers.OrderBy(s => s.Length)));
    
    Console.ReadKey();
