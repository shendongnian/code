    function Validate(string Input)
    {
       System.Text.RegularExpressions.Regex MyRegex = new 
       System.Text.RegularExpressions.Regex("([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))");
       return MyRegex.Match(Input).Success // returns true or false
    }
