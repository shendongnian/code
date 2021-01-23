    public ActionMethod CreateCustomer(string custName)
    {
        if (IsAcceptableRange(custName))
        { 
           //continue
        }
    }
    public bool IsAcceptableRange(string input)
    {
       //whitelist all the valid inputs here. be sure to include 
       //space, period, apostrophe, hypen, etc
       Regex alphaNumericPattern=new Regex("[^a-zA-Z0-9]");
       return !alphaNumericPattern.IsMatch(input); 
    }
