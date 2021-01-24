    public static string StripHtml(string text)
        {
            string ignorePattern = null;
            if (!string.IsNullOrEmpty(text))
            {
                text = text.Replace("&lt;", "<");
                text = text.Replace("&gt;", ">");
    
                text = text.Replace("<p>", "<p> ");
                ignorePattern = string.Format("{0}(?!p)(?!/p)", ignorePattern);
                
                ignorePattern = string.Format(@"<{0}[^<]*>", ignorePattern);
                text = Regex.Replace(text, ignorePattern, "", RegexOptions.IgnoreCase);
            }
    
            return text;
        }
