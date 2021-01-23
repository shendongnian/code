     var list = new[]
     { 
        new { Number = 10, Name = "Smith" },
        new { Number = 10, Name = "John" } 
     }.ToList();
     foreach (var item in list)
     {
        Console.WriteLine(item.Name);
     }
