    int totalPercentages = 0; 
    int destinationsIndex = -1;
    for(int i = 0; i < destinationPercentageArrays.Length; i++)
    {
        totalPercentages += destinationPercentageArrays[i];
        if (totalPercentages > RandomNumberBetween0and100)
        {
            destinationIndex = i;
            break;
        }
    }
    if (destinationIndex == -1)
    {
       throw new Exception("Something went badly wrong.");
    }
