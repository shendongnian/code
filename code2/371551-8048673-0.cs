    GetErrorByField(string str)
    {
       var splited = str.Split(",:".ToCharArray());
       if (splited != null && splited.Length == 3)
          return splited[2];
       return string.Empty;
    }
