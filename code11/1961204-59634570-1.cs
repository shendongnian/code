    public static void Main(string[] args)
    {
        var realtors = new List<Realtor>();
        for (int i = 0; i < 3; i++)
        {
            var realtor = new Realtor();
            Console.Write("Please enter the employee name: ");
            realtor.Name = Console.ReadLine();
            Console.Write("Please enter the number of Properties Sold: ");
            realtor.PropertiesSold = int.Parse(Console.ReadLine());
            realtors.Add(realtor);
            Console.WriteLine();
        }
        realtors = realtors.OrderByDescending(realtor => realtor.PropertiesSold).ToList();
        foreach (var realtor in realtors)
        {
            Console.WriteLine(realtor);
        }
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
