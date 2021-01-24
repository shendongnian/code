    if (s4 == null) { 
          //^ this was missing
        System.Console.WriteLine("Student Not Found");
    } else {
        System.Console.WriteLine($"{s4.FirstName} {s4.LastName} {s4.Major?.Description}");
        var db = new AppEfDbContext();
    }
