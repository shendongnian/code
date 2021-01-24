    public static void Method(int n)
        {
            if (IsPrime(n))
            {
                Console.WriteLine($"{n} is a prime");
                return;
            }
            var divisors = new List<int>();
            for(var i = 1; i <= n; i++)
            {
                if (n % i == 0)
                    divisors.Add(i);
            }
            Console.WriteLine($"{n} isn't a prime");
            Console.WriteLine($"The divisors are: {string.Join(", ", divisors)}");
        }
        public static bool IsPrime(int n)
        {
            for(var i = 2; i < n; i++)
            {
                if (n % i == 0)
                    return false;
            }
            
            return true;
        }
