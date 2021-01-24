    public static int Persistence(long n)
    {
        if (n < 10) // handle the trivial cases - stop condition
        {
            return 0;
        }
        long pro = 1; // int may not be big enough, use long instead
        while (n > 0) // simplify the problem by one level
        {
            pro *= n % 10;
            n /= 10;
        }
        return 1 + Persistence(pro); // 1 = one level solved, call the same function for the rest
    }
