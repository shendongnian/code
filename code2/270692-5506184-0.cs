    /// <summary>Parses the input string and extracts a unique list of all placeholders.</summary>
    /// <remarks>
    ///  This method does not handle escaping of delimiters
    /// </remarks>
    public static IList<string> Parse(string input)
    {
        const char placeholderDelimStart = '{';
        const char placeholderDelimEnd = '}';
        var characters = input.ToCharArray();
        var placeHolders = new List<string>();
        string currentPlaceHolder = string.Empty;
        bool inPlaceHolder = false;
        for (int i = 0; i < characters.Length; i++)
        {
            var currentChar = characters[i];
            // Start of a placeholder
            if (!inPlaceHolder && currentChar == placeholderDelimStart)
            {
                currentPlaceHolder = string.Empty;
                inPlaceHolder = true;
                continue;
            }
            // Start of a placeholder when we already have one
            if (inPlaceHolder && currentChar == placeholderDelimStart)
                throw new InvalidOperationException("Unexpected character detected at position " + i);
            // We found the end marker while in a placeholder - we're done with this placeholder
            if (inPlaceHolder && currentChar == placeholderDelimEnd)
            {
                if (!placeHolders.Contains(currentPlaceHolder))
                    placeHolders.Add(currentPlaceHolder);
                inPlaceHolder = false;
                continue;
            }
            // End of a placeholder with no matching start
            if (!inPlaceHolder && currentChar == placeholderDelimEnd)
                throw new InvalidOperationException("Unexpected character detected at position " + i);
            if (inPlaceHolder)
                currentPlaceHolder += currentChar;
        }
        return placeHolders;
    }
