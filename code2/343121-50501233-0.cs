    Use bellow code to validate(Regex patterns) Alphabetic and numbers
    
    String name="123ABCabc";
    
    if(System.Text.RegularExpressions.Regex.Match(name, @"[0-9a-zA-Z_]")==true)
    {
      return true;
    }
    else 
    {
       return false;
    }
