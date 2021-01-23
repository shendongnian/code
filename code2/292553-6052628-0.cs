    Regex regexObj = new Regex(@"\w;([\d|.]+)\|?");
    Match matchResults = regexObj.Match("g;13|g;100|g;0");
    if( matchResults.IsMatch )
    {
       for (int i = 1; i < matchResults.Groups.Count; i++) 
       {
          Group groupObj = matchResults.Groups[i];
          if (groupObj.Success) 
          {
             //groupObj.Value will be the number you want
          } 
       }
    }
