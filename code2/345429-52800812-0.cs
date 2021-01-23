    long start = Time();
    long end = Time();
    Console.WriteLine("Benchmark Runtime: " + (end - start) + " Microseconds");
    for(int k = 0; k < 5; k++)
    {
        start = Time();
        int j;
        for (int i = 0; i < 900000000; i++)
        {
            j = i;
        }
        end = Time();
        Console.WriteLine("Benchmark 1: " + (end - start) + " Microseconds");
    }
    for (int k = 0; k < 5; k++)
    {
        start = Time();
        for (int i = 0; i < 900000000; i++)
        {
            int j = i;
        }
        end = Time();
        Console.WriteLine("Benchmark 2: " + (end - start) + " Microseconds");
    }
