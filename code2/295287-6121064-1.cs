    int n = 4;
    int max = 1 << n;
    for (long val = 1; val < max; val++)
    {
        long mask = 1 << (n - 1);
        for (int bit = 0; bit < n; bit++)
        {
            bool set = (val & mask) != 0;
            Console.Write(set ? "1 " : "0 ");
            mask >>= 1;
        }
        Console.WriteLine();
    }
