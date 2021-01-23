    public static string CleanInvalidXmlChars(string text) 
    { 
         // From xml spec valid chars: 
         // #x9 | #xA | #xD | [#x20-#xD7FF] | [#xE000-#xFFFD] | [#x10000-#x10FFFF]     
         // any Unicode character, excluding the surrogate blocks, FFFE, and FFFF. 
         string re = @"[^\x09\x0A\x0D\x20-\xD7FF\xE000-\xFFFD\x10000-x10FFFF]"; 
         return Regex.Replace(text, re, ""); 
    }
