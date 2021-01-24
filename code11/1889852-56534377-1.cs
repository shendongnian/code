    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"(CP_[A-Z_]+),";
            string input = @"LTRIM(RTRIM(ISNULL(CP_RENOUNCEABLE,'x2x'))), ISNULL(CP_RIGHTS_OFFER_TYP,-1), LTRIM(RTRIM(ISNULL(CP_SELLER_FEED_SOURCE,'x2x'))),
                     LTRIM(RTRIM(ISNULL(CP_SELLER_ID_BB_GLOBAL,'x2x'))),ISNULL(CP_PX,-1), ISNULL(CP_RATIO,-1), ISNULL(CP_RECLASS_TYP,-1);";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
