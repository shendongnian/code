       public static string FirstToUpper(this string lowerWord)
       {
           if (string.IsNullOrWhiteSpace(lowerWord) || string.IsNullOrEmpty(lowerWord))
                return lowerWord;
           return new StringBuilder(lowerWord.Substring(0, 1).ToUpper())
                     .Append(lowerWord.Substring(1))
                     .ToString();
       }
