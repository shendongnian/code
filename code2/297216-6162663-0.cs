    static void Main(string[] args)
    {
        var r = new Random(3);
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(r.NextDouble(0, 1));
        }
        Console.ReadKey();
    }
    public static double NextDouble(this Random r, double Lower, double Upper)
    {
        return Lower + ((r.Next(100) + 1) * (Upper - Lower) / 100);
    }
