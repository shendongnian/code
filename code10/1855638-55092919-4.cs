    string ReplaceNonAlphaNum(string str)
    {
       var builder = new StringBuilder(); 
       foreach (var ch in str)
       {
           if (asciiAlphaNum.Contains(ch))
                 builder.Append(ch);
           else
                 builder.AppendFormat("_x{0:x4}_", (int)ch);
       }
       return builder.ToString();    
    }
    string ReplaceNonAlphaNumLinq(string str)
    {
	   return str.Aggregate(new StringBuilder(), (builder, ch) => 
           asciiAlphaNum.Contains(ch) ? 
              builder.Append(ch) : builder.AppendFormat("_x{0:x4}_", (int)ch)			
       ).ToString();
    }
