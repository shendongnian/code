    public interface ICommandHandler
    {
        void Handle(ICommandContext context, string commandName, string[] arguments);
    }
    
    public class CommandService : IMyHandler
    {
        public void Add(string commandName, ICommandHandler handler) 
        {
        }
    
        public void Handle(IProcessContext context, string line)
        {
           // first word on the line is the command, all other words are arguments.
           // split the string properly
           
           // then find the corrext command handler and invoke it.
           // take the result and add it to the `IProcessContext`
        }
    }
