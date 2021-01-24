        private static bool Size ()
        {
            bool goodChoice;
            do
            {
              goodChoice = true;
              Console.WriteLine("Pizza size:\n S)mall(5.00)\n M)eduium(6.25)\n L)arge(8.75)");
              Console.Write("Choose one: ");
              var choice = Console.ReadLine();
              double cost = 0;
              switch (choice)
              {
                  case "S":
                   cost += 5.00;
                   break;
                  case "M":
                   cost += 6.25;
                   break;
                  case "L":
                   cost += 8.75;
                   break;
                  default:
                   goodChoice = false;
                   Console.WriteLine("Invalid Selection please select S, M, or L");
                   break;
              }
            } while (!goodChoice)
            return (true);
        }
You could also have the methods return false if they don't make a good choice and then loop on the return value of Size, Sauce and Cheese:
bool goodValue = false;
while (!goodValue)
  goodValue = Size();
