        string str = "to title case";
        Console.WriteLine(Regex.Replace(str, @"\b[a-z]", delegate (Match m) 
                                                      {
                                                          return m.Value.ToUpper();
                                                      }
                          ));
