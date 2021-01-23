    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace WebProject.Core.Utilities
    {
        public static class StringExtensions
        {
            public static string Sanitize(this string s)
            {
                //your code to sanitize your string, for example
                if(s == null) throw new ArgumentNullException("s");
                var trimmed = input.Trim();
                return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(trimmed);
            }
        }
    }
