    var random = new Random();
    int numberTarget = random.Next(1, 50 + 1);
    int numberUser;
    do
    {
      Console.Write("Please enter a number between 1 and 50: ");
      if ( int.TryParse(Console.ReadLine(), out numberUser) )
      {
        if ( numberUser > numberTarget )
        {
          Console.WriteLine("Too high, retry.");
        }
        else 
        if ( numberUser < numberTarget )
        {
          Console.WriteLine("Too low, retry.");
        }
        else
        {
          Console.WriteLine($"Bang on the answer was {numberTarget}.");
        }
      }
      else
      {
        Console.WriteLine("You didn't enter a valid number, retry.");
      }
    }
    while ( numberUser != numberTarget );
    Console.WriteLine("Press a key to exit.");
    Console.ReadKey();
