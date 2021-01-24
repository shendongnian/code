    static string GetUserString(string letters)
    {
      string result;
      bool isValid;
      do
      {
        Console.Write("Enter : ");
        result = Console.ReadLine();
        isValid = true;
        foreach ( char c in result )
          if ( letters.IndexOf(char.ToUpper(c)) == -1 )
          {
            isValid = false;
            Console.WriteLine("Enter a valid input");
            break;
          }
      }
      while ( !isValid );
      return result;
    }
