    private static List<ulong> KnownPrimes = new List<ulong>();
    private static ulong LargestValue = 1UL;
    private static List<ulong> GetFastestPrimeNumbers(ulong number)
    {
        var result = new List<ulong>();
        lock (KnownPrimes)
        {
            result.AddRange(KnownPrimes.Where(c => c < number).ToList());
            if (number <= LargestValue)
            {
                return result;
            }
            result = KnownPrimes;
            for (var i = LargestValue + 1; i <= number; i++)
            {
                var isPrime = true;
                var n = Math.Floor(Math.Sqrt(i));
                for (var j = 0; j < KnownPrimes.Count; j++)
                {
                    var jVal = KnownPrimes[j];
                    if (jVal * jVal > i)
                    {
                        //isPrime = false;
                        break;
                    }
                    else if (i % jVal == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    result.Add(i);
                }
            }
            LargestValue = number;
        }
        return result;
    }
