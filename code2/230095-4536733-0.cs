    public static int calculateTheSumOfPrimesBelow(int maxPrimeBelow)
        {
            // we know 2 is a prime number
            long sumOfPrimes = 2;
    
            int currentNumberBeingTested = 3;
            while (currentNumberBeingTested < maxPrimeBelow)
            {
                double squareRootOfNumberBeingTested = (double)Math.Sqrt(currentNumberBeingTested);
    
                bool isPrime = true;
                for (int i = 2; i <= squareRootOfNumberBeingTested; i++)
                {
                    if (currentNumberBeingTested % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
    
                if (isPrime)
                    sumOfPrimes += currentNumberBeingTested;
    
                currentNumberBeingTested += 2; // as we don't want to test even numbers
            }
            if(sumOfPrimes>int.Maxvalue) return>0
           else
            return (int)sumOfPrimes;
        }
