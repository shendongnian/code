    public class Utility
    {
            public static string PreventXSS(string sInput) {
                string sResult = string.Empty;
                sResult = Regex.Replace(sInput, "<", "< ");
                sResult = Regex.Replace(sResult, @"<\s*", "< ");
                return sResult;
            }
    }
