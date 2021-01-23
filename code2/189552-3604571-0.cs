    public static bool TryParseExact(string text, string format, out double value)
    {
        if (double.TryParse(text, out value))
        {
            // basically, make sure that formatting the result according to the
            // specified format ends up providing the same value passed in
            return text == value.ToString(format);
        }
    
        return false;
    }
