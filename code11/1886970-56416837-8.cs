    int Upper = Tally.GetUpperBound(0);
    int Lower = Tally.GetLowerBound(0);
    
    Console.WriteLine("Roll\t\tCount\t\t");
    
    for (int Count = 0; Count <= Upper; ++Count)
    {
        Console.WriteLine("{0}\t\t{1}\t\t", Count + 1, Tally[Count]);
    }
