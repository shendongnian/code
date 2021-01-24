    private Regex _strip = new Regex( "[^0-9+]", RegexOptions.Compiled);
    public string CleanPhoneNumber(string messynumber){
        if(Regex.IsMatch(messynumber, "[a-z]"))
          return "";
        else
          return _strip.Replace(messynumber, "");
    }
    ...
    for(int x = 0; x < millionStrArray.Length; x++)
      millionStrArray[x] = CleanPhonenumber(millionStrArray[x], "");
