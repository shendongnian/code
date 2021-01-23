    public static class Extension
    {
        public static string ToSQEscapedStringJS<T>(this T unescapedStr)
        {
            if (unescapedStr == null || unescapedStr.ToString() == "")
            {
                return "''";
            }
            // replace ' by @@@
            var escapedStr = (unescapedStr).ToString().Replace("'", "@@@"); 
            // JS code to replace @@@ by '
            string unEscapeSQuote = "replace(/@{3}/g, String.fromCharCode(0x27))"; 
            // add @@@ escaped string with conversion back to '
            return $"('{escapedStr}'.{unEscapeSQuote})"; 
        }
    }
