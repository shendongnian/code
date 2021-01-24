    int counter = 1;
    TinasDice();
    bool playAgain = false;
    do
    {
      Console.WriteLine("Do you want to play again?");
      playAgain = Console.ReadLine().ToLower() == "yes";
      if ( playAgain )
      {
        counter++;
        TinasDice();
      }
    }
    while ( playAgain );
    Console.WriteLine("The number of times the dice was die was thrown is: " + counter);
    Console.WriteLine("Nice game!");
    Console.WriteLine("Thanks for playing. Come play again soon!");
