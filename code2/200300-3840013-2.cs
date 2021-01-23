    class Program
    {
      private enum Command
      {
        CommandOne = 1,
        CommandTwo = 2,
        CommandThree = 3
      }
    
      static void Main(string[] args)
      {
        var command = Enum.Parse(typeof(Commands), args[0]);
        switch(command )
        {
          case Command.CommandOne: //do something 
            break;
          case Command.CommandTwo: //do something else
            break;
          case Command.CommandThree: //do something totally different
            break;
          default: //do your default stuff
            break;
        }
      }
    }
