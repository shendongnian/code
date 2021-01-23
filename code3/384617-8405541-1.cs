    string[] count = { "one ", "two ", "three ", "four ", "five ", "six " }; 
    IEnumerable<int> results = count.Select(item => 
                               { 
                                          Console.WriteLine(item); 
                                          return item.Length; 
                               })
                              .ToList()
                              .Take(2);
