     private static string RemoveUnquotedWhiteSpaces(string text)
     {    
        string result = String.Empty;
        var parts = text.Split('"');
        for(int i = 0; i < parts.Length; i++)
        {
           if (i % 2 == 0) result += Regex.Replace(parts[i], " ", "");
           else result += String.Format("\"{0}\"", parts[i]);
        }
        return result
      }
