    public static string StripTabsAndNewlines(this string s) {
  
        //string builder (fast)
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < str.Length; i++) {
            if ( !  Char.IsWhiteSpace(s[i])) {
                sb.Append();
            }
        }
        return sb.tostring();
        
        //linq (faster ?)
        return new string(input.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray());
        
        //regex (slow)
        return Regex.Replace(s, @"\s+", "")
        
    }
