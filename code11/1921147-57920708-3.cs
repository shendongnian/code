    private static string ReadName(string title) {
      while (true) {
        if (!string.IsNullOrEmpty(title)) 
          Console.WriteLine(title);
        // .Trim() - let be nice and tolerate leading / trailing whitespaces
        string name = Console.ReadLine().Trim(); 
        if (IsValidName(name))
          return name;
        Console.WriteLine("Sorry, the name is not valid. Please, try again");
      }
    }
