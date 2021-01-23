     /// <summary>
                   /// Replaces  not expected characters.
                   /// </summary>
                   /// <param name="text"> The text.</param>
                   /// <param name="allowedPattern"> The allowed pattern in Regex format, expect them wrapped in brackets</param>
                   /// <param name="replacement"> The replacement.</param>
                   /// <returns></returns>
                   /// //        http://stackoverflow.com/questions/4460290/replace-chars-if-not-match.
                   //http://stackoverflow.com/questions/6154426/replace-remove-characters-that-do-not-match-the-regular-expression-net
                   //[^ ] at the start of a character class negates it - it matches characters not in the class.
                   //Replace/Remove characters that do not match the Regular Expression
                   static public string ReplaceNotExpectedCharacters( this string text, string allowedPattern,string replacement )
                  {
                         allowedPattern = allowedPattern.StripBrackets( "[", "]" );
                          //[^ ] at the start of a character class negates it - it matches characters not in the class.
                          var result = Regex .Replace(text, @"[^" + allowedPattern + "]", replacement);
                          return result;
                  }
    
    static public string RemoveNonAlphanumericCharacters( this string text)
                  {
                          var result = text.ReplaceNotExpectedCharacters(NonAlphaNumericCharacters, "" );
                          return result;
                  }
            public const string NonAlphaNumericCharacters = "[a-zA-Z0-9]";
