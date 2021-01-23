     public static class Helper
        {
            public static string Unescape(this string val)
            {
                return val.Replace(@"\n", "\n").Replace(@"\t", "\t");
            }
        }
