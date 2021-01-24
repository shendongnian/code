    namespace Rock__Paper__Scissors_
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Lets play a game of Rock, Paper, Scissors.");
                Console.Write("Enter Rock, Paper or Scissors:");
                string userChoice = Console.ReadLine();
    
                Random r = new Random();
                int computerChoice = r.Next(2);
    
    
                //0 = Scissors
                if (computerChoice == 0)
                {
                    if (userChoice == "Scissors")
                    {
                        Console.WriteLine("Computer chose scissors!");
                        Console.WriteLine("TIE!");
                    }
    
                    else if (userChoice == "Rock")
                    {
                        Console.WriteLine("Computer chose Scissors!");
                        Console.WriteLine("You WIN!");
                    }
    
                    else if (userChoice == "Paper")
                    {
                        Console.WriteLine("Computer chose Scissors");
                        Console.WriteLine("You LOSE!");
    
                    }
                }
    
                //1 = Rock
                else if (computerChoice == 1)
                {
                    if (userChoice == "Scissors")
                    {
                        Console.WriteLine("Computer chose Rock!");
                        Console.WriteLine("You LOSE!");
                    }
    
                    else if (userChoice == "Rock")
                    {
                        Console.WriteLine("Computer chose Rock!");
                        Console.WriteLine("TIE!");
                    }
    
                    else if (userChoice == "Paper")
                    {
                        Console.WriteLine("Computer chose Rock");
                        Console.WriteLine("You WIN!");
                    }
                }
    
                //2 = Paper
                else if (computerChoice == 2)
                {
                    if (userChoice == "Scissors")
                    {
                        Console.WriteLine("Computer chose Paper!");
                        Console.WriteLine("You WIN");
                    }
    
                    else if (userChoice == "Rock")
                    {
                        Console.WriteLine("Computer chose Paper!");
                        Console.WriteLine("You LOSE!");
                    }
    
                    else if (userChoice == "Paper")
                    {
                        Console.WriteLine("Computer chose Paper");
                        Console.WriteLine("TIE!");
                    }
                }
    
     
                //Exception Handling
                if (userChoice != "Scissors")
                {
                    Console.WriteLine("Choose Rock, Paper or Scissors");
                }
    
                else if (userChoice != "Rock")
                {
                    Console.WriteLine("Choose Rock, Paper or Scissors");
                }
    
                else if (userChoice != "Paper")
                {
                    Console.WriteLine("Choose Rock, Paper or Scissors");
                }
    
    
            }
        }
    }
