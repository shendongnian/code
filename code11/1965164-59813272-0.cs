c#
using System;
using System.Collections.Generic;
namespace MyProgram
{
    class Program
    {
        // Don't actually use inner classes. This is just for demonstration purposes.
        class Command
        {
            public Command(string description, Action action)
            {
                this.Description = description;
                this.Action = action;
            }
            public string Description { get; private set; }
            public Action Action { get; private set; }
        }
        static void Main(string[] args)
        {
            // Create a dictionary of commands, mapped to the input that evokes each command.
            var availableCommands = new Dictionary<string, Command>();
            // Note that since we are storing the descriptions / commands in one place, it makes
            // changing a description or adding/modifying a command trivial. Want "Draw" to be invoked
            // by "d" instead of "1"? Change it here and you're done.
            availableCommands.Add("1", new Command("Draw", Draw));
            availableCommands.Add("2", new Command("Stay", Stay));
            // This command demonstrates how to use a lambda as an action if you so desire.
            availableCommands.Add("3", new Command("Exit", () => System.Environment.Exit(1)));
            // Build command list string
            var cmdList = string.Join('/', availableCommands.Keys);
            // Display welcome message
            Coloration(ConsoleColor.DarkMagenta, $"What do you want to do? [{cmdList}]");
            // Show user initial list of commands
            DisplayAvailableCommands(availableCommands);
            // Read Eval Print Loop (REPL).
            while (true)
            {
                var userInput = Console.ReadLine();
                // If the user entered a valid command, execute it.
                if (availableCommands.ContainsKey(userInput))
                {
                    availableCommands[userInput].Action();
                    // If you want the user to be able to perform additional actions after their initial successful
                    // action, don't return here.
                    return;
                }
                // Otherwise, let them know they didn't enter a valid command and show them a list of commands
                else
                {
                    Coloration(ConsoleColor.Red, "Please enter a valid answer.");
                    DisplayAvailableCommands(availableCommands);
                }
            }
        }
        // I'm just assuming your coloration method looks something like this...
        static void Coloration(ConsoleColor color, string message)
        {
            // Keep track of original color so we can set it again.
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = originalColor;
        }
        static void DisplayAvailableCommands(Dictionary<string, Command> commands)
        {
            // We always want a line above the commands
            Console.WriteLine("Available commands:");
            foreach (string key in commands.Keys)
            {
                var command = commands[key];
                Console.WriteLine($"{key}. {command.Description}");
            }
        }
        static void Draw()
        {
            Coloration(ConsoleColor.DarkGreen, "You chose to draw!");
        }
        static void Stay()
        {
            Coloration(ConsoleColor.DarkGreen, "You chose to stay!");
        }
    }
}
Adding new commands will be a breeze. And you can further refactor this to even smaller single-purpose methods. Each command could have its' own class in the event that your commands become more complicated (and in a real app, they will. Trust me). You can refactor the REPL to its' own class/method as well (take a look at [this implementation I did a while back](https://github.com/DeanPDX/sql-fileizer/blob/master/InteractiveUserInterface.cs) for example).
Anyway, this is my $.02 on a more correct way you could build a user interface of this nature. Your current solution is going to work, but it's not going to be fun to work with long-term. Hopefully this helps.
