    string MakeAcronym(string input)
    {
        var chars = input.Where(Char.IsUpper).ToArray();
        return new String(chars);
    }
    // MakeAcronym("Transmission Control Protocol") == "TCP"
