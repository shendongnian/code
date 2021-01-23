    public string Get2LineDisplayText(string original)
    {
          int mid=original.Length /2;
          if (!Char.IsWhitespace(original[mid]))
          {
               for(int i=1; i< mid; +=i)
               {
                   if (Char.IsWhitespace(original[mid+i])
                   {
                         mid = mid+i;
                         break;
                   }
                   if (Char.IsWhitespace(original[mid-i])
                   {
                         mid = mid-i;
                         break;
                   }
               }
           }
           return original.Substring(0, mid-1) 
                     + "<br />" + original.Substring(mid+1) 
    }
    
