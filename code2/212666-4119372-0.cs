    private static List<int> primes = new List<int>() {2};
    public static IEnumerable<int> Primes()
    {
        int p;
        foreach(int i in primes) {p = i; yield return p;}
        while (p < int.MaxValue)
        {
           p++;
           bool isPrime = true;
           foreach(int i in primes)
           {
               if (p % i == 0)
               {
                    isPrime = false;
                    break;
               }
           }          
           if (isPrime)
           {
               primes.Add(p);
               yield return p;
           }
        }          
    }
    public int LargestPrimeFactor(int n)
    {
         return Primes.TakeWhile(p => p <= Math.Sqrt(n)).Where(p => n % p == 0).Last();
    }
