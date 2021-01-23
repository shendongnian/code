    private static long CalcPassword2(long p)
            {
                p++;
                List<int> factors = new List<int>();
    
                for (int i = 1; i <= p; i++)
                {
                    if (p % i == 0)
                        if (isprime(i))
                        {
                            factors.Add(i);
                        }
                }
                int answer = 0;
                foreach (int prime in factors)
                {
                    answer = answer + prime;
                }
                return answer;
            }
