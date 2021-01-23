    private static readonly Regex _validator = 
        new Regex(@"^\d{4}-\d{5}-\d{4}-\d{3}$", RegexOptions.Compiled);
    private static bool ValidateInput(string input)
    {
        input = (input ?? string.Empty);
        if (input.Length != 19)
        {
            return false;
        }
        return _validator.IsMatch(input);
    }
