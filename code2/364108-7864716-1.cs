    public static void Main()
    {
        double d = 1.0;
        d -= 0.3;
        d -= 0.2;
        Console.WriteLine("Standard formatting: {0}", d); // 0.5
        Console.WriteLine("Internal Representation: {0:r}", d); // 0.49999999999999994
        Console.WriteLine("Console WriteLine 0 decimals: {0:0}", d); // 1
        Console.WriteLine("0 decimals Math.Round: {0}", Math.Round(d, MidpointRounding.AwayFromZero)); // 0
        Console.WriteLine("15 decimals then 0 decimlas Math.Round: {0}", Math.Round(Math.Round(d, 15, MidpointRounding.AwayFromZero), MidpointRounding.AwayFromZero)); // 1
    }
