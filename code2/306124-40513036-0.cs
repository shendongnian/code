    /// <summary>
    /// Turn a string into a CSV cell output
    /// </summary>
    /// <param name="value">String to output</param>
    /// <returns>The CSV cell formatted string</returns>
    private string ConvertToCsvCell(string value)
    {
        var mustQuote = value.Any(x => x == ',' || x == '\"' || x == '\r' || x == '\n');
        if (!mustQuote)
        {
            return value;
        }
        value = value.Replace("\"", "\"\"");
        return string.Format("\"{0}\"", value);
    }
