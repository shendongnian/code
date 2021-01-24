    class Program
    {
      static void Main()
      {
        string strName;
        do
        {
          Console.WriteLine("What is your name, please?");
          strName = Console.ReadLine();
          foreach ( char c in strName )
            if ( !char.IsLetter(c) )
            {
              Console.WriteLine();
              Console.WriteLine("Your name can only contains letters.");
              Console.WriteLine();
              strName = null;
              break;
            }
        }
        while ( strName == null );
        Console.WriteLine();
        Console.WriteLine("Your name is: " + strName);
        Console.WriteLine();
        Console.WriteLine("Press a key to exit.");
        Console.ReadKey();
      }
    }
