    int Upper = Tally.GetUpperBound(0); // This is equal to Tally.Length
    int Lower = Tally.GetLowerBound(0); // This is equal to 0.
    
    Console.WriteLine("Roll\t\tCount\t\t");
    
    for (int Count = Lower; Count <= Upper; Count++)
    {
        Console.WriteLine("{0}\t\t{1}\t\t", Count + 1, Tally[Count]);
    }
