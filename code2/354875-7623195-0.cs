    string s = "24:Something(true;false;true)[0,1,0]";
    Regex pattern = new Regex(@"^\d{1,3}:[a-zA-z]{1,10}\((true|false)(;true|;false)*\)\[\d(,\d)*\]$");
    
    if (pattern.IsMatch(s))
    {
       // s is valid
    }
