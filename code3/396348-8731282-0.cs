    public static string GenerateNewCode(int CodeLength)
    {
    string newCode = String.Empty;
    int seed = unchecked(DateTime.Now.Ticks.GetHashCode());
    Random random = new Random(seed);
    
    // keep going until we find a unique code       `
    do
    {	
    // The firstPart int will be a random number that has a length of 6, 7, 8, ,9, or 10 digits
    int firstPart = random.Next(100000,2147483647);
    
    // The secondPart int will be a random number that has a length of two digits
    int secondPart = random.Next(10,99);		
    
    // Concatenate firstPart and secondPart. This will create a string that has a length of 8, 9, 10, 11, or 12 chars.
    newCode = firstPart.ToString() + secondPart.ToString();
    
    }
    while (!ConsumerCode.isUnique(newCode));
    
    // return
    return newCode;
    }
