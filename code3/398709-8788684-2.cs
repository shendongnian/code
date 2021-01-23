    public class Prog
    {
        public Prog()
        {
            var factory = new CommandFactory();
            factory.Register("A", () => new A().DoA);
            factory.Register("B", () => new B().DoB);
            factory.Register("C", factory.DoStuff);
            factory.Execute("A");
        }
    }
    public class CommandFactory
    {
        private readonly IDictionary<string, Action> _commands;       
        public void Register(string commandName, Action action)
        {
		_commands.Add(commandName, action); 
        }
        public void Execute(string commandName)
        {
            _commands[commandName]();
        }
        public void DoStuff()
        {
        }
    }
    public class A
    {
        public void DoA()
        {
        }
    }
    public class B
    {
        public void DoB()
        {
        }
    }
