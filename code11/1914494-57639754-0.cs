    private static bool IsPrime(int n)
            {
                if(n < 4)
                {
                    return true;
                }
    
                for(int i = 0; i * i < n; i++)
                {
                    if(n % i == 0)
                    {
                        return false;
                    }
                }
    
                return true;
            }
