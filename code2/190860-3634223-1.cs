    int totalPercentages = 0; 
    int destinationsIndex = -1;
    int randomNumberBetween0and100 = GetRandomNumber();
    for(int i = 0; i < destinationPercentageArrays.Length; i++)
    {
        totalPercentages += destinationPercentageArrays[i];
        if (totalPercentages > randomNumberBetween0and100)
        {
            destinationIndex = i;
            break;
        }
    }
    if (destinationIndex == -1)
    {
       throw new Exception("Something went badly wrong.");
    }
