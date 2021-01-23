    using Spring.Context;
    using Spring.Context.Support;
    public class CommandManager
    {
      Dictionary<CommandType, string> { get; set; } // set using DI; values are object names
    
      public Command GetBy(CommandType cmdKey)
      {
        string objName = Dictionary[cmdKey];
        IApplicationContext ctx = ContextRegistry.GetContext();
        
        return (Command)ctx.GetObject(objName);
      } 
    }
