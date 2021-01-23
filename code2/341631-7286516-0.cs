    static decimal RequestDecimal(string message)
    {
        decimal result;
        do 
        {
             Console.WriteLine(message);
        }
        while (!decimal.TryParse(Console.ReadLine(), out result));
        return result;
    }
