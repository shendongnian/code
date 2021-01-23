    private static List<int> primes = new List<int>() {2};
    public static IEnumerable<int> Primes()
    {
        int p;
        foreach(int i in primes) {p = i; yield return p;}
        while (p < int.MaxValue)
        {
           p++;
           if (!primes.Any(i => p % i ==0))
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
