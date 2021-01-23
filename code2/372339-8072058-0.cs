    public static bool IsEmpty(this string s) 
    { 
        Contract.Ensures(Contract.Result() == string.IsNullOrWhitespace(s))
        return string.IsNullOrWhitespace(s);
    } 
    public static bool IsNotEmpty(this string s) 
    { 
        Contract.Ensures(Contract.Result() == !string.IsNullOrWhitespace(s))
        return !string.IsNullOrWhitespace(s);
    } 
