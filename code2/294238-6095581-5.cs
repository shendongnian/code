    public string GetErrorDescription(string errorNumbers)
    {
      string retStr;
      if (errorNumbers.Length == 6)
      {
        int errorCode;  
        if(int.TryParse(errorNumbers.Substring(0,4), out errorCode))
        {
          errorsCache.TryGetValue(errorCode, out retStr);
        }
      }
    
      return retString;
      // or you can return empty string instead of null
      return retString ?? "";
    }
