    private static string GetOpeningSpan(char chr)
    {
        // return an opening span with the correct color
        var validCharacters = new[] 
            {'F', 'L', 'R', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        if (!validCharacters.Contains(chr)) return "<span>";
        var color = chr == 'F' ? "pink" : chr == 'L' ? "red" : chr == 'R' ? "green" : "orange";
        return $"<span style=\"color: {color}\">";
    }
    private const string ClosingSpan = "</span>";
    private static string GetHighlightedString(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return input;
        // Add the opening span and first character
        var result = new StringBuilder().Append(GetOpeningSpan(input[0]) + input[0]);
        for (int i = 1; i < input.Length; i++)
        {
            var thisChar = input[i];
            var prevChar = input[i - 1];
            // If this character is the same as the previous one, just add it
            if (thisChar == prevChar || (char.IsDigit(thisChar) && char.IsDigit(prevChar)))
            {
                result.Append(thisChar);
            }
            else
            {
                // Add a closing span, and opnening span, and this character
                result.Append(ClosingSpan + GetOpeningSpan(thisChar) + thisChar);
            }
        }
        // Add a final closing span
        result.Append(ClosingSpan);
        return result.ToString();
    }
