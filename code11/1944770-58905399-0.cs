    public static DateTime ApplyInput(this DateTime dt, string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input), "The input string must be null.");
        }
        if (input.Length < 3)
        {
            throw new ArgumentException("The input string is too short to include both a number and an operation.", nameof(input));
        }
        string numberChars = input.Substring(0, input.Length - 2);
        if (!int.TryParse(numberChars, out int number))
        {
            throw new ArgumentException("The start of the input string must be an integer.", nameof(input));
        }
        string endingChars = input.Substring(input.Length - 2);
        switch (endingChars.ToUpperInvariant())
        {
            case "MM":
                return dt.AddMonths(number);
            case "DD":
                return dt.AddDays(number);
            default:
                throw new ArgumentException($"The characters {endingChars} were not recognized as a valid operation.", nameof(input));
        }
    }
