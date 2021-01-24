      public static int ReadInteger(string title) {
        if (!string.ISNullOrWhiteSpace(title))  
          Console.WriteLine(title);
        while (true) {
          if (int.TryParse(Console.ReadLine(), out int result))
            return result;
          Console.WriteLine("This is not a valid integer! Try again.");
        }
      }
      public static string FeedBack(int user, int actual) {
        if (user < 0 || user > 100)
          return "Between 1 and 100, Dummy!"
        else if (user < actual)
          return "Too Low!  /n Try again.";
        else if (user > actual)
          return "Too High! /n Try again.";
        else
          return "JACKPOT!"
      }
       
