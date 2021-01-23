    public int GetFactorCount(int numberToCheck)
    {
        int factorCount = 0; 
        // Start from 1 as we want our method to also work when numberToCheck is 0 or 1.
        int i;
        for (i = 1; i * i < numberToCheck; i++)
        {
            if (numberToCheck % i == 0)
            {
                factorCount += 2; //  We found a pair of factors.
            }
        }
        // Check if our number is an exact square.
        if (i * i == numberToCheck)
        {
            factorCount++;
        }
        return factorCount;
    }
