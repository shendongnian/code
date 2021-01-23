    namespace Input_Program
    {
        class Program
        {
            static void Main()
            {
                char Y = Console.ReadKey().KeyChar;
                Console.WriteLine("Welcome to my bool program!");
                Console.WriteLine("Input a NON capital y or n when told to.");
                if(Y == 'y')
                {
                    Console.WriteLine("Thank you,Please wait.....");
                    Console.WriteLine("You input Y");
                }
                else
                {
                    if(Y == 'n')
                    {
                        Console.WriteLine("You input N");
                    }
                }
                Console.ReadLine();
            }
        }
    }        
