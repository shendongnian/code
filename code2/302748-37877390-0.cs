    [MembershipPasswordAttribute(MinRequiredNonAlphanumericCharacters = 4, MinRequiredPasswordLength = 7, MinNonAlphanumericCharactersError = "Alpha", MinPasswordLengthError = "MIN Length")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [System.ComponentModel.DataAnnotations.Compare("Password",ErrorMessage  ="{0} and {1} should be same")]
    public string ComparePassword { get; set; }
