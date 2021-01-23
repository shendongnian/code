    bool ContainsInvalidCharacters(string input)
    {
        // check if there is a non-digit character
        foreach (char c in input)
            if (!char.IsDigit(c))
                return true;
        return false;
    }
