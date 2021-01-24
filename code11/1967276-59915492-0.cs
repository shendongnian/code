    using System;
    
    namespace Application
    {
    class Program
    {
        static void Main(string[] args)
        {
            //Fields
            bool welcome = false;
    
            while (Utility.Quit == false)
            {
                if (welcome == false)
                {
                    Console.WriteLine("Welcome to CSF Scheduler. Please enter a command to get started.");
                    Console.WriteLine("Type 'HELP' for a list of commands.");
                    welcome = true;
                }
                Utility.GetCommand(()=>Console.ReadLine());
                Utility.HandleCommand(Utility.Command);
            }
        }
    }
    
    public abstract class Utility
    {
        public Utility()
        {
        }   
    
        //Fields
        public static string Command { get; private set; }
    
        public static bool Quit { get; private set; }
    
    
            //Methods
        public static void GetCommand( Func<string> command)
        {
            Console.Write("Please enter your command: ");
            Command = command();
        }
    
        public static void HandleCommand(string command)
        {
            switch (Command)
            {
                case "QUIT":
                    Quit = true;
                    break;
            default:
            Console.WriteLine("Command not recognized. Please type 'HELP' to see a list of commands.");
                break;
            }
        }
    }
    }
