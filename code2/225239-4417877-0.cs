    string[] token = { "foo", "bar" };
    string text = "blaah foo bar text";
    
    text = text.ReplaceAll(token, "");
    public static class StringHelper
    {
        public static string ReplaceAll(this string text, 
                                        string[] token, 
                                        string replacement)
        {
            string newText = text;
            foreach (string s in token)
                newText = newText.Replace(s, replacement);
            return newText;
        }
    }
