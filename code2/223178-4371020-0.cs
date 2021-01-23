    private static readonly Regex boxNumberRegex = new Regex(@"^\d-\d{5}$");
    public bool VerifyBoxNumber (string boxNumber)
    {
       return boxNumberRegex.IsMatch(boxNumber);
    }
