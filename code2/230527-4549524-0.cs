    public int GetHowManyFactors(int numberToCheck)
    {
        // we know 1 is a factor and the numberToCheck
        int factorCount = 2; 
        
        int i = 2 + ( numberToCheck % 2 ); //start at 2 (or 3 if numberToCheck is odd)
        for( ; i < numberToCheck / 2; i+=2) 
        {
            if (numberToCheck % i == 0)
                factorCount++;
        }
        return factorCount;
    }
