    using System.Linq;
    ...
    public static string ReplaceAll(
      string str, char[] charsToReplace, char replacementCharacter) 
    {
       // Please, note IsNullOrEmpty syntax
       // we should validate charsToReplace as well
       if (string.IsNullOrEmpty(str) || null == charsToReplace || charsToReplace.Length <= 0)
         return str; // let's just do nothing (say, not turn null into empty string)
    
       return string.Concat(str.Select(c => charsToReplace.Contains(c) 
         ? replacementCharacter
         : c));
    }
