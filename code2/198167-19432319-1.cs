    public static class StringExtensions
    {
         public static string StripHTML(this string htmlString, string htmlPlaceHolder) {
             const string pattern = @"<.*?>";
             string sOut = Regex.Replace(htmlString, pattern, htmlPlaceHolder, RegexOptions.Singleline);
             sOut = sOut.Replace("&nbsp;", String.Empty);
             sOut = sOut.Replace("&amp;", "&");
             sOut = sOut.Replace("&gt;", ">");
             sOut = sOut.Replace("&lt;", "<");
             return sOut;
         }
    }
