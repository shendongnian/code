    public static bool IsNumeric(this string input)
    {
        if (string.IsNullOrWhitespace(input))
            return false;
        double result;
        return Double.TryParse(input, out result);
    }
