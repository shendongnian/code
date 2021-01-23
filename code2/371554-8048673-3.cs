    GetErrorByField(string str)
    {
       var splited = str.Split(":".ToCharArray());
       if (splited != null && splited.Length == 2)
          return splited[1].TrimStart().TrimEnd();
       return string.Empty;
    }
