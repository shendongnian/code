    int Highest(int[] numbers)
    {
        int highest = Int32.MinValue();
    
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > highest)
                highest = numbers[i];
        }
    
        return highest;
    }
    
    int Lowest(int[] numbers)
    {
        int lowest = Int32.MaxValue();
    
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < lowest)
                lowest = numbers[i];
        }
    
        return lowest;
    }
