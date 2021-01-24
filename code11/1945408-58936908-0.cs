    [Required(AllowEmptyStrings = false, ErrorMessage = "Email darf nicht leer sein.")]
    [BindRequired]
    [RegularExpression(EmailRegex)]
    public string Email { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Passwort darf nicht leer sein.")]
    [BindRequired]
    public string Password { get; set; }
