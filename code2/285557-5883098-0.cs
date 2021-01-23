    public static string ChangePage(string sUrl)
    {
      string sRc = string.Empty;
      const string sToReplace = "&page=--PLACEHOLDER--";
    
      Regex regURL = new Regex(@"http://.*(&page=(\d+)).*");
    
      Match mPage =  regURL.Match(sUrl);
      if (mPage.Success) {
        GroupCollection gc = mPage.Groups;
        string sCapture = gc[1].Captures[0].Value;
        // gc[2].Captures[0].Value) is the page number
        sRc = sUrl.Replace(sCapture, sToReplace);
      }
      else {
        sRc = sUrl+sToReplace;
      }
    
      return sRc;
    }
