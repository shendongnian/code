    public string CleanPhoneNumber(string messynumber){
        if(Regex.IsMatch(messynumber, "[a-z]"))
          return "";
        else
          return Regex.Replace(messynumber, "[^0-9+]", "");
    }
