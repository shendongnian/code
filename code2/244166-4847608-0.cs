    public static string StripHtml(string html, bool allowHarmlessTags)
    {
       if (html == null || html == string.Empty)
         return string.Empty; 
    
       if (allowHarmlessTags)
         return System.Text.RegularExpressions.Regex.Replace(html, "", string.Empty); 
    
       return System.Text.RegularExpressions.Regex.Replace(html, "<[^>]*>", string.Empty);
    }
