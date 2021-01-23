    private static List<ulong> KnownPrimes = new List<long>();
    private static ulong LargestValue = 1UL;
    private unsafe static List<ulong> FindPrimes(ulong number)
    {
        var result = new List<ulong>();
        var isPrime = new bool[number + 1];
        var sqrt = Math.Sqrt(number);
        lock (KnownPrimes)
        {
            fixed (bool* pp = isPrime)
            {
                bool* pp1 = pp;
                result.AddRange(KnownPrimes.Where(c => c < number).ToList());
                if (number <= LargestValue)
                {
                    return result;
                }
                result = KnownPrimes;
                for (ulong x = 1; x <= sqrt; x++)
                    for (ulong y = 1; y <= sqrt; y++)
                    {
                        var n = 4 * x * x + y * y;
                        if (n <= number && (n % 12 == 1 || n % 12 == 5))
                            pp1[n] ^= true;
                        n = 3 * x * x + y * y;
                        if (n <= number && n % 12 == 7)
                            pp1[n] ^= true;
                        n = 3 * x * x - y * y;
                        if (x > y && n <= number && n % 12 == 11)
                            pp1[n] ^= true;
                    }
                for (ulong n = 5; n <= sqrt; n++)
                    if (pp1[n])
                    {
                        var s = n * n;
                        for (ulong k = s; k <= number; k += s)
                            pp1[k] = false;
                    }
                if (LargestValue < 3)
                {
                    KnownPrimes.Add(2);
                    KnownPrimes.Add(3);
                }
                for (ulong n = 5; n <= number; n += 2)
                    if (pp1[n])
                        KnownPrimes.Add(n);
                LargestValue = number;
            }
        }
        return result;
    }
