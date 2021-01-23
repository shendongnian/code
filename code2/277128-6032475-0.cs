    public static string CorrectTextCasing(this string text)
    {
        //  /[.:?!]\\s[a-z]/ matches letters following a space and punctuation,
        //  /^(?:\\s+)?[a-z]/  matches the first letter in a string (with optional leading spaces)
        Regex regexCasing = new Regex("(?:[.:?!]\\s[a-z]|^(?:\\s+)?[a-z])", RegexOptions.Multiline);
                  
        //  First ensure all characters are lower case.  
        //  (In my case it comes all in caps; this line may be omitted depending upon your needs)        
        text = text.ToLower();
        
        //  Capitalize each match in the regular expression, using a lambda expression
        text = regexCasing.Replace(text, s => (s.Value.ToUpper));
        
        //  Return the new string.
        return text;
        
    }
