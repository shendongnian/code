    using System.Text.RegularExpressions;
    boolean IsGoodPassword(string pwd){
        int minPwdLen = 8;
        int maxPwdLen = 12;
        boolean allowableChars = false;
        boolean oneLetterOneNumber = false;
        boolean goodLength = false;
        string allowedCharsPattern = "^[a-z0-9]*$";
        
        //Does it pass the test for containing only allowed chars?
        allowableChars = Regex.IsMatch(pwd, allowedCharsPattern , RegexOptions.IgnoreCase));
        //Does it contain at least one # and one letter?
        oneLetterOneNumber = Regex.IsMatch(pwd, "[0-9]")) && Regex.IsMatch(pwd, "[a-z]", RegularExpressions.IgnoreCase));
        //Does it pass length requirements?
        goodLength = pwd.Length >= minPwdLength && pwd.Length <= maxPwdLength;
        return allowableChars && oneLetterOneNumber && goodLength;
    }
