        public static bool IsEncoded(string text)
        {
            // below fixes false positive &lt;<> 
            // you could add a complete blacklist, 
            // but these are the ones that cause HTML injection issues
            if (text.Contains("<")) return false;
            if (text.Contains(">")) return false;
            if (text.Contains("\"")) return false;
            if (text.Contains("'")) return false;
            if (text.Contains("script")) return false;
            // if decoded string == original string, it is already encoded
            return (System.Web.HttpUtility.HtmlDecode(text) != text);
        }
        public static bool NeedsEncoding(string text)
        {
            return !IsEncoded(text);
        }
