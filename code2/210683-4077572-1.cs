    char[] charArray = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
     
    List<String> MyList = new List<string>();
    int n = 1000;
    
                          (from value1 in charArray
                           select new
                           {
                               newString = value1.ToString()
                           })
                       .Union
                       (
                           (from value1 in charArray
                            from value2 in charArray
    
                            select new
                            {
                                newString = string.Concat(value1, value2)
                            })
                        )
                        .Union
                        (
                            (from value1 in charArray
                             from value2 in charArray
                             from value3 in charArray
    
                             select new
                             {
                                 newString = string.Concat(value1, value2, value3)
                             })
                         )
                         .ToList()
                         .ForEach(i => MyList.Add(i.newString));
          MyList = MyList.Take(n).ToList<string>();
