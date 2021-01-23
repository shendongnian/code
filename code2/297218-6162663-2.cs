    static void Main(string[] args)
    {
        var r = new Random(3);
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(r.NextDouble(0, 1, 100));
        }
        Console.ReadKey();
    }
    public static double NextDouble(this Random r
        , double lower
        , double upper
        , int scale = int.MaxValue - 1
        )
    {
        var d = lower + ((r.Next(scale + 1)) * (upper - lower) / scale);
        return d;
    }
