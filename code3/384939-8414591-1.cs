    public class PasswordValidator
    {
        public bool IsValid(string password)
        {
            return password.Length > MinimumLength
                && uppercaseCharacterMatcher.Matches(password).Count
                    >= FewestUppercaseCharactersAllowed
                && digitsMatcher.Matches(password).Count >= FewestDigitsAllowed
                ;
        }
        public int FewestUppercaseCharactersAllowed { get; set; }
        public int FewestDigitsAllowed { get; set; }
        public int MinimumLength { get; set; }
        private Regex uppercaseCharacterMatcher = new Regex("[A-Z]");
        private Regex digitsMatcher = new Regex("[a-z]");
    }
    var validator = new PasswordValidator()
    {
        FewestUppercaseCharactersAllowed = x,
        FewestDigitsAllowed = y,
        MinimumLength = z,
    };
    return validator.IsValid(password);
