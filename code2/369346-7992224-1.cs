        private static List<int> GetPrimeNumbers2(long number)
        {
            var result = new List<int>();
            for (var i = 0; i <= number; i++)
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
                }
            }
            return result;
        }
