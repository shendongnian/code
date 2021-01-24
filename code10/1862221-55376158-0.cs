    namespace UnNamed Project
    {
        class Program
        {
            static void Main(string[] args)
            {
                User user;
                user = new SuperUser("Bob", "12345");
    
                if (user.Login())
                {
                    Console.WriteLine($"Welcome {user.Name}");
                }
                else
                {
                    Console.WriteLine("An error has occured.");
                }
    
                Utility.PauseBeforeContinuing();
            }
        }
    }
