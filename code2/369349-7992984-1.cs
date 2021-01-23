    public static List<int> GeneratePrimesParallel(int n)
        {
          var sqrt = (int) Math.Sqrt(n);
          var lowestPrimes = GeneratePrimes(sqrt);
          var highestPrimes =  (Enumerable.Range(sqrt + 1, n - sqrt)
                                    .AsParallel()
                                    .Where(i => lowestPrimes.All(prime => i % prime != 0)));
          return lowestPrimes.Concat(highestPrimes).ToList();
        }
