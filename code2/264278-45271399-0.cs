    public static class CommonExtensions
    {
        public static bool IsValidEmail(this string thisEmail)
            => !string.IsNullOrWhiteSpace(thisEmail) &&
               new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").IsMatch(thisEmail);
    }
