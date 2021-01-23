    static void Main(string[] args)
    {
        RollingMean mean = new RollingMean(10, 7);
        mean.Push(3);
        mean.Push(4);
        mean.Push(5);
        mean.Push(6);
        mean.Push(7.125);
        Console.WriteLine( mean.Mean );
        Console.ReadLine();
    }
