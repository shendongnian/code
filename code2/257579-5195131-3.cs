    public class CommandManager
    {
      Dictionary<CommandType, Command> { get; set; } // set using DI
    
      public Command GetBy(CommandType cmdKey)
      {
        return Dictionary[cmdKey];
      } 
    }
