    private static List<long> KnownPrimes = new List<long>();
    private static long LargestValue = -1;
    private static List<long> GetPrimeNumbers(long number)
    {
        var result = new List<long>();
        lock (KnownPrimes)
        {
            result.AddRange(KnownPrimes.Where(c => c < number).ToList());
            if (number <= LargestValue)
            {
                return result;
            }
            for (var i = LargestValue + 1; i <= number; i++)
            {
                var isPrime = true;
                var n = Math.Floor(Math.Sqrt(i));
                for (var j = 2; j <= n; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    result.Add(i);
                    KnownPrimes.Add(i);
                }
            }
            LargestValue = number;
        }
        return result;
    }
