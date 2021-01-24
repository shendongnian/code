static void Test()
{
  MainMenu();
}
static uint GetUserChoice(Action printMenu, int choiceMax)
{
  uint choice = 0;
  Action getInput = () =>
  {
    uint.TryParse(Console.ReadLine(), out choice);
  };
  getInput();
  Console.WriteLine();
  while ( choice < 1 || choice > choiceMax )
  {
    Console.WriteLine();
    Console.WriteLine("Please try again");
    printMenu();
    getInput();
  }
  return choice;
}
static void MainMenu()
{
  Action printMenu = () =>
  {
    Console.WriteLine("Press 1 if you are a customer");
    Console.WriteLine("Press 2 if you are a manager");
    Console.WriteLine("Press 3 to Exit");
  };
  Console.Clear();
  Console.WriteLine("-----------------------------------------------------------------------------------------------------------"); // introducing the user with the menu 
  Console.WriteLine("Welcome to VideoMart at University Boulevard!");
  Console.WriteLine("At VideoMart you are able to rent a variety of movies from many genres such as action, family, horror, etc!");
  Console.WriteLine();
  printMenu();
  Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
  uint choice = GetUserChoice(printMenu, 3);
  switch ( choice )
  {
    case 1:
      CustomerMenu();
      break;
    case 2:
      //ManagerMenu();
      break;
    case 3:
      Console.WriteLine("Thank you for visiting VideoMart at University Boulevard, Goodbye!");
      break;
  }
}
static void CustomerMenu()
{
  Action printMenu = () =>
  {
    Console.WriteLine("Press 1 to view movies available to rent.");
    Console.WriteLine("Press 2 to rent a movie.");
    Console.WriteLine("Press 3 to view a list of movies you currently have rented.");
    Console.WriteLine("Press 4 to return a movie rented.");
    Console.WriteLine("Press 5 to return to main menu.");
  };
  Console.Clear();
  Console.WriteLine("-----------------------------------------------------------------------------------------------------------"); // introducing the user with the menu 
  Console.WriteLine("Below is a list of actions that can be performed by customers!");
  Console.WriteLine();
  printMenu();
  Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
  Console.WriteLine();
  uint choice = GetUserChoice(printMenu, 5);
  switch ( choice )
  {
    case 1:
      //MoviesAvailable();
      break;
    case 2:
      //RentMovie();
      break;
    case 3:
      //RentedMovies();
      break;
    case 4:
      //ReturnMovie();
      break;
    case 5:
      MainMenu();
      break;
  }
}
