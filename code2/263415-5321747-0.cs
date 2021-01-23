    public static bool isEmail(string inputEmail)
    {
       inputEmail  = NulltoString(inputEmail);
       string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
             @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + 
             @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
       Regex re = new Regex(strRegex);
       if (re.IsMatch(inputEmail))
        return (true);
       else
        return (false);
    }
