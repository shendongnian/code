    IEnumerable<string> GetSplittedAboveLimit(string inputString,int limit)
    {
       var splitted = inputString.Split(".");
       foreach(var input in splitted)
       {
          if(input.Length > limit)
          {
              yield return input; 
          }
       }
    }
