    class Program
    {
      private Dictionary<string, IYourCommand> Command = new Dictionary<string, IYourCommand>
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
    public interface IYourCommand
    {
      void DoSomething();
    }
    
