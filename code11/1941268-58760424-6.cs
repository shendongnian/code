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
    default:
      throw new NotImplementedException();
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
    default:
      throw new NotImplementedException();
  }
}
**Using an auto-menu manager**
Here is the menu choice class:
    public class MenuChoice
    {
      public string Title { get; private set; }
      public Action Action { get; private set; }
      public MenuChoice(string title, Action action)
      {
        Title = title;
        Action = action;
      }
    }
Here is the menu class:
public class Menu
{
  private readonly string Separator = new string('-', 100);
  private string Header;
  private List<MenuChoice> Choices;
  private Menu Root;
  public Menu(string header, List<MenuChoice> choices, Menu root)
  {
    Header = header;
    Choices = choices;
    Root = root;
  }
  private void Print()
  {
    for ( int index = 0; index < Choices.Count; index++ )
      Console.WriteLine($"Press {index + 1} {Choices[index].Title}");
    Console.WriteLine($"Press {Choices.Count + 1} to {( Root == null ? "exit" : "go to previous menu" )}");
  }
  public void Run()
  {
    Console.Clear();
    Console.WriteLine(Separator);
    Console.WriteLine(Header);
    Console.WriteLine();
    Print();
    Console.WriteLine(Separator);
    uint choice = GetUserChoice();
    if ( choice == Choices.Count + 1 )
      if ( Root == null )
      {
        Console.WriteLine("Thank you for visiting VideoMart at University Boulevard, Goodbye!");
        return;
      }
      else
        Root.Run();
    else
    {
      var action = Choices[(int)choice - 1].Action;
      if ( action != null )
        action();
      else
      {
        Console.WriteLine("Not implemented yet, press a key to continue.");
        Console.ReadKey();
        Run();
      }
    }
  }
  uint GetUserChoice()
  {
    uint choice = 0;
    Action getInput = () =>
    {
      uint.TryParse(Console.ReadLine(), out choice);
    };
    getInput();
    Console.WriteLine();
    while ( choice < 1 || choice > Choices.Count + 1 )
    {
      Console.WriteLine();
      Console.WriteLine("Please try again");
      Print();
      getInput();
    }
    return choice;
  }
}
Here is the menu manager class:
public class MenuManager
{
  private Menu Root;
  public MenuManager(Menu root)
  {
    Root = root;
  }
  public void Run()
  {
    Root.Run();
  }
}
Here the menu manager initialization, using methods or another menu instead of null in choices:
    var choicesMain = new List<MenuChoice>();
    var choicesCustomer = new List<MenuChoice>();
    var choicesManager = new List<MenuChoice>();
    string headerMain = "Welcome to VideoMart at University Boulevard!" + Environment.NewLine +
                        "At VideoMart you are able to rent a variety of movies from many genres such as action, family, horror, etc!";
    string headerCustomer = "Below is a list of actions that can be performed by customers!";
    string headerManager = "Below is a list of actions that can be performed by managers!";
    var root = new Menu(headerMain, choicesMain, null);
    var menuCustomer = new Menu(headerCustomer, choicesCustomer, root);
    var menuManager = new Menu(headerManager, choicesManager, root);
    choicesMain.Add(new MenuChoice("if you are a customer", menuCustomer.Run));
    choicesMain.Add(new MenuChoice("if you are a manager", menuManager.Run));
    choicesCustomer.Add(new MenuChoice("to view movies available to rent.", null));
    choicesCustomer.Add(new MenuChoice("to rent a movie.", null));
    choicesCustomer.Add(new MenuChoice("to view a list of movies you currently have rented.", null));
    choicesCustomer.Add(new MenuChoice("to return a movie rented.", null));
Now all to do is:
    new MenuManager(root).Run();
