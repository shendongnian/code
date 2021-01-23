    static void Main(string[] args)
    {
        Console.WriteLine("Year");
        var year = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Month");
        var month = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Day");
        var day = Int32.Parse(Console.ReadLine());
        var customDate = new DateTime(year, month, day);
        Console.WriteLine(customDate);
        Console.ReadLine();
    }
