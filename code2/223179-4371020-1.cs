    private static readonly Regex boxNumberRegex = new Regex(@"^\d-\d{5}$");
    public static bool VerifyBoxNumber (string boxNumber)
    {
       return boxNumberRegex.IsMatch(boxNumber);
    }
