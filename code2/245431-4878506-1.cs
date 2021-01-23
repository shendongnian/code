    using System.Text.RegularExpressions;
    ...
    const string HTML_TAG_PATTERN = "<.*?>";
     
    static string StripHTML (string inputString)
    {
       return Regex.Replace 
         (inputString, HTML_TAG_PATTERN, string.Empty);
    }
