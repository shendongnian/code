    string words = "Hello World This is a great world, This World is simply great".ToLower();
    
    var results = words.Split(' ').Where(x => x.Length > 3)
                                  .GroupBy(x => x)
                                  .Select(x => new { Count = x.Count(), Word = x.Key })
                                  .OrderByDescending(x => x.Count);
    
    foreach (var item in results)
        Console.WriteLine(String.Format("{0} occured {1} times", item.Word, item.Count));
    
    Console.ReadLine();
