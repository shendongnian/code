    public static class DateTimeExtensions
    {
            static string[] extensions = // 0 1 2 3 4 5 6 7 8 9 
                { "th", "st", "nd", "rd", "th", "th", "th", "tn", "th", "th", 
                    // 10 11 12 13 14 15 16 17 18 19 
                    "th", "th", "th", "th", "th", "th", "th", "tn", "th", "th", 
                    // 20 21 22 23 24 25 26 27 28 29 
                    "th", "st", "nd", "rd", "th", "th", "th", "tn", "th", "th", 
                    // 30 31 
                    "th", "st" 
                };
            public static string ToSpecialString(this DateTime dt)
            {
                string s = dt.ToString(" MMMM yyyy");
                string t = string.Format("{0}{1}", dt.Day, extensions[dt.Day]);
                return t + s;
            }
    }
