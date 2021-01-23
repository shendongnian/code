    class Program
    {
      private Dictionary<string, ICommand> Command = new Dictionary<string, ICommand>
        {
           { "CommandOne",   new CommandOne()   },
           { "CommandTwo",   new CommandTwo()   },
           { "CommandThree", new CommandThree() },
           { "CommandFour",  new CommandFour()  },
        };
    
      public static void Main(string[] args)
      {
        if (Command.ContainsKey(args[0]))
        {
          Command[args[0]].DoSomething();
        }
      }
    }
    
