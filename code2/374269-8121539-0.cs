    public static string CustomHtmlEncode(string value) 
    {    
       char[] chars = HttpUtility.HtmlEncode(YourDbString).ToCharArray(); 
       StringBuilder encodedValue = new StringBuilder(); 
       foreach(char c in chars) 
       { 
          if ((int)c > 127) // above normal ASCII 
             encodedValue.Append("&#" + (int)c + ";"); 
          else 
             encodedValue.Append(c); 
       } 
       return encodedValue.ToString(); 
    }
