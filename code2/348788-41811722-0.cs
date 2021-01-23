    string s = "12fg";
    
    if(s.All(char.IsDigit))
    {
       return true; // contains only digits
    }
    else
    {
       return false; // contains not only digits
    }
