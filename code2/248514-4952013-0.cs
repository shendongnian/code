    static private long maxfactor (long n)
    {
        while (n > 2 && !(n & 1)) n >> 1;
    
        long k = 3;
        while (k * k <= n)
        {
            if (n % k == 0)
            {
                n /= k;
            }
            else
            {
                k += 2;
            }
        }
    
        return n;
    }
