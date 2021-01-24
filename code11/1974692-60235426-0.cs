    var list = new List<int>();
    
    while (true)
    {
       Console.Write("Enter an element (Enter to end): ");
       var result = Console.ReadLine();
    
       if (result == string.Empty) break;
       if (!int.TryParse(result, out var value))
       {
          Console.WriteLine("You had one job...");
          continue;
       }
       list.Add(value);
    } 
    
    Console.WriteLine(string.Join(", " , list));
    
    Console.ReadKey();
