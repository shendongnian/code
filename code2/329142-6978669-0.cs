    // C#
    public interface ICommand { void Execute(); }
    public interface ICommandFactory { ICommand Create(); }
    public class CommandFactoryManager
    {
        private IDictionary<string, ICommandFactory> factories;
        public CommandFactoryManager()
        {
            factories = new Dictionary<string, ICommandFactory>();
        }
        public void RegisterCommandFactory(string name, ICommandFactory factory)
        {
            factories[name] = factory;
        }
        // ...
    }
