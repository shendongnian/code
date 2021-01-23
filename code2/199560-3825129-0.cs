    var list = new[] { new { ID = 1, Name = "John" },
                       new { ID = 2, Name = "Mark" },
                       new { ID = 3, Name = "George" } }.ToList();
    
    Console.WriteLine(list.ToAndList(x => (x.ID + ": " + x.Name)));
