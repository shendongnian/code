    bool ContainsRepetitiveDigits(string input)
    {
        if (input.Length == 0)
            return false;
        // get the first character
        char firstChar = input[0];
        
        // check if there is a different character
        foreach (char c in input)
            if (c != firstChar)
                return false;
        // if not, it means it's repetitive
        return true;
    }
    bool StartsWithZero(string input)
    {
        if (input.Length == 0)
            return false;
        return (input[0] == '0');
    }
