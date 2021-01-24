    void Main()
    {
        DateTime? startDate = new DateTime(2019, 3, 5, 3, 0, 0);
        DateTime? endDate = new DateTime(2019, 3, 15, 4, 0, 0);
        
        TimeSpan result = (endDate - startDate).Value;
        Console.WriteLine(result.ToString(@"dd\:hh\:mm\:ss"));
    }
