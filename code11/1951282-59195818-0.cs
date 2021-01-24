    List<string> specialChars = new List<string> {"*", "/", "&"}
    
    for (var i = 0; i < specialChars.Count; i++) 
    {
      test = test.Replace(specialChars[i],"");
    }
