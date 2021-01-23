    protected bool IsValidPhone(string strPhoneInput)
    {
    // Remove symbols (dash, space and parentheses, etc.)
    string strPhone = Regex.Replace(strPhoneInput, @”[- ()\*\!]“, String.Empty);
    
    // Check for exactly 10 numbers left over
    Regex regTenDigits = new Regex(@”^\d{10}$”); 
    Match matTenDigits = regTenDigits.Match(strPhone);
    
    return matTenDigits.Success;
    }
