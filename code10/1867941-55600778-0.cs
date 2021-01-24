    private string CheckForEscapeStringInQuotesAndTrim(string csvDataValue)
    {
        if (Regex.IsMatch(csvDataValue, "[,\"\\r\\n]"))
        {
            return $"\"{csvDataValue.Replace("\"", "\"\"")}\"";
        }
        //trim any unnecessary whitespace
        return csvDataValue.Trim();
    }
