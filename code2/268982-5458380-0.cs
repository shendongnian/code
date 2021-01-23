    public void Linq46()
    {
        int[] factorsOf300 = { 2, 2, 3, 5, 5 };
     
        var uniqueFactors = factorsOf300.Distinct();
     
        Console.WriteLine("Prime factors of 300:");
        foreach (var f in uniqueFactors)
        {
            Console.WriteLine(f);
        }
    }
