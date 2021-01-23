    static IList<BigInteger> GetFactors(BigInteger n)
    {
        List<BigInteger> factors = new List<BigInteger>();
        BigInteger x = 2;
        while (x <= n)
        {
            if (n % x == 0)
            {
                factors.Add(x);
                n = n / x;
            }
            else
            {
                x++;
                if (x * x >= n)
                {
                    factors.Add(n);
                    break;
                }
            }
        }
        return factors;
    }
