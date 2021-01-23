    public static List<int> GeneratePrimes(int n)
    {
      var primes = new List<int>();
      for(var i = 2; i <= n; i++)
      {
        var ok = true;
        foreach(var prime in primes)
        {
          if (prime * prime > i)
            break;
          if (i % prime == 0)
          {
            ok = false;
            break;
          }
        }
        if(ok)
          primes.Add(i);
      }
      return primes;
    }
