         stringToDecorate = Regex.Replace(stringToDecorate, urlFinder.ToString(), m =>
         {
           if (string.IsNullOrEmpty(m.Groups[2].ToString()))
           {
               return @"<a href='http://" +  m.Groups[1].Value + @"'>" + m.Groups[1].Value + @"</a>";
           }
           else
           {
              return @"<a href='" +  m.Groups[1].Value + @"'>" + m.Groups[1].Value + @"</a>";
            }
     });
