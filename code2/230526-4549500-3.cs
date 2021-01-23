    public int GetFactorCount(int numberToCheck)
    {
        int factorCount = 0;
        int sqrt = (int)Math.Ceiling(Math.Sqrt(numberToCheck));
        // Start from 1 as we want our method to also work when numberToCheck is 0 or 1.
        for (int i = 1; i < sqrt; i++)
        {
            if (numberToCheck % i == 0)
            {
                factorCount += 2; //  We found a pair of factors.
            }
        }
        // Check if our number is an exact square.
        if (sqrt * sqrt == numberToCheck)
        {
            factorCount++;
        }
        return factorCount;
    }
