    public class Program
    {
        private ICommandFactory _commandFactory;
    
        public static void Main(string[] argv)
        {
            // this is the only line that is really dependent of a specific
            // implementation.
            _commandFactory = new TheSpecificImplementationAssembly.CommandFactory();
    
            ICommand command = _commandFactory.Create("CreateUser");
            command.Execute();
        }
    }
