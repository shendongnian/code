    public bool Validate(string input)
    {
        if (input == null || input.Length < 8)
            return false;
        int counter = 0;
        if (input.Any(Char.IsLower)) counter++;
        if (input.Any(Char.IsUpper)) counter++;
        if (input.Any(Char.IsDigit)) counter++;
        if (input.Any(c => Char.IsPunctuation(c) || Char.IsSymbol(c))) counter++;
        return counter >= 3;
    }
