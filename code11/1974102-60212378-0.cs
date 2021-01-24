    Console.WriteLine("Give input");
    string input = Console.ReadLine();
    
    string pattern = @"([A-Z]{2,})";
    string[] words = Regex.Split(input, pattern);
    
    foreach (var w in words)
     if(Regex.IsMatch(w,pattern)
      Console.WriteLine(w);
