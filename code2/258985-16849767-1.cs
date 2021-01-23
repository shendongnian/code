    public static string StripTabsAndNewlines(this string str) {
  
        //string builder (fast)
        StringBuilder sb = new StringBuilder(str.Length);
        for (int i = 0; i < str.Length; i++) {
            if ( !  Char.IsWhiteSpace(s[i])) {
                sb.Append();
            }
        }
        return sb.tostring();
        
        //linq (faster ?)
        return new string(str.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray());
        
        //regex (slow)
        return Regex.Replace(str, @"\s+", "")
        
    }
