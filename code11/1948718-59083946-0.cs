    namespace ConsoleApp12
    {
        class Program
        {
            static void Main(string[] args)
            {
                Game game1 = new Game();
                game1.SetQuestion1(GetInput(game1));
                game1.game();
                game1.DisplayAll();
    
                Console.WriteLine("End of game");
                Console.ReadKey();
            }
    
            public static string GetInput(Game game)
            {
                do
                {
                    string input;
                    Console.WriteLine("Please enter your choice: Rock - 1, Paper - 2, Scissors - 3");
                    input = Console.ReadLine();
                    return input;
                }
                while (game.win < 4 || game.lose < 4 || game.usermoney == 0);
            }
        }
    }
    namespace ConsoleApp12
    {
        class Game
        {
            public double usermoney = 100;
            public double win = 0;
            public double lose = 0;
            public double userchoice, computerchoice;
    
            public void game()
            {
                if (userchoice == 1 && computerchoice == 3)
                {
                    win++;
                    usermoney = usermoney + 20;
                }
                else if (userchoice == 2 && computerchoice == 1)
                {
                    win++;
                    usermoney = usermoney + 20;
                }
                else if (userchoice == 3 && computerchoice == 2)
                {
                    win++;
                    usermoney = usermoney + 20;
                }
                else if (userchoice == 0)
                {
                    Environment.Exit(0);
                }
                else
                {
                    lose++;
                    usermoney = usermoney - 10;
                }
            }
            public double SetQuestion1(string param1)
            {
                userchoice = double.Parse(param1);
                return userchoice;
            }
            public double Computer()
            {
                Random rnd = new Random();
                computerchoice = rnd.Next(1, 3);
                return computerchoice;
            }
            public void DisplayAll()
            {
                Console.WriteLine("User chose: " + userchoice + ", Computer chose: " + computerchoice + ". Remember, 1 = Rock, 2 = Paper, 3 = Scissors");
                Console.WriteLine("User balance is " + usermoney);
                if (userchoice == 1 && computerchoice == 3)
                {
                    Console.WriteLine("User Wins - +$20");
                }
                else if (userchoice == 2 && computerchoice == 1)
                {
                    Console.WriteLine("User Wins - +$20");
                }
                else if (userchoice == 3 && computerchoice == 2)
                {
                    Console.WriteLine("User Wins - +$20");
                }
                else
                {
                    Console.WriteLine("User Loses - -$10");
                }
            }
        }
    }
