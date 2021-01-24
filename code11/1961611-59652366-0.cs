    private static void PrintDT(DateTime? dt)
    {
        if (dt.HasValue)
        {
            DateTime valueOrDefault = dt.GetValueOrDefault();
            Console.WriteLine(valueOrDefault);
        }
    }
