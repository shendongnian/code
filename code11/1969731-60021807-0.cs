    static int Check_Prime(BigInteger p)
    {
        int i;
        for (i = 2; i <= p /2; i++)
        {
            if (p % i == 0)
            {
                return 0; //not a prime number
            }
        }
        if (i == p) // never true except p == 0
        {
            return 1;
        }
        return 0; // always returns 0
    }
