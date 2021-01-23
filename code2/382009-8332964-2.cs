    private static void Main(string[] args)
    {
        var objectList = Enumerable.Range(0, 5).Select(i => new { DecimalValue = (decimal)31.45, Id = 3 }).ToList();
        var result = (objectList.Any()) ? objectList.Distinct().Sum(x => x.DecimalValue) : 0;
        Console.WriteLine(result);
        Console.ReadKey();
    }
