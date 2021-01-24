    public static void Main(string[] args)
    {
        var realtors = new List<Realtor>();
        for (var i = 0; i < 3; i++)
        {
            var realtor = new Realtor();
            Console.Write("Please enter the employee name: ");
            realtor.Name = Console.ReadLine();
            realtor.PropertiesSold = GetIntFromUser(
                "Please enter the number of Properties Sold: ", x => x >= 0);
            realtors.Add(realtor);
            Console.WriteLine();
        }
        realtors = realtors.OrderByDescending(realtor => realtor.PropertiesSold).ToList();
        Console.WriteLine("Results in order of most properties sold:\n");
        Console.WriteLine($"{"Name".PadRight(10)} Properties Sold");
        Console.WriteLine($"{new string('-', 10)} {new string('-', 15)}");
        foreach (var realtor in realtors)
        {
            Console.WriteLine($"{realtor.Name.PadRight(10)} {realtor.PropertiesSold}");
        }
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
