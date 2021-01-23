    private static bool IsEmailValid(string email)
        {
            System.Text.RegularExpressions.Regex re = new Regex(@"^[\p{L}0-9!$'*+\-_]+(\.[\p{L}0-9!$'*+\-_]+)*@[\p{L}0-9]+(\.[\p{L}0-9]+)*(\.[\p{L}]{2,})$", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
            
            return re.IsMatch(email);
        }
