    public class Prog2
    {
        public Prog2()
        {
            var factory = new CommandFactory2();
            factory.Register("A", new Lazy<Command>(
                ()=>
                    {
                        var a = new A();
                        return new Command(a.DoA, a.UndoA);
                    }));
            factory.Register("B", new Lazy<Command>(
               () =>
               {
                   var c = new B();
                   return new Command(c.DoB, c.DoB);
               }));
            factory.Register("C", new Lazy<Command>(
                () => new Command(DoStuff, UndoStuff)));
            factory.Execute("A");
        }
        public static void DoStuff()
        {
        }
        public static void UndoStuff()
        {
        }
    }
    public class CommandFactory2
    {
        private readonly IDictionary<string, Lazy<Command>> _commands;
        public void Register(string commandName, Lazy<Command> lazyCommand)
        {
            _commands.Add(commandName, lazyCommand);
        }
        public void Register(string commandName, Action execute, Action undo)
        {
            _commands.Add(commandName, new Lazy<Command>(() => new Command(execute, undo)));
        }
        public Command GetCommand(string commandName)
        {
            return _commands[commandName].Value;
        }
        public void Execute(string commandName)
        {
            GetCommand(commandName).Execute();
        }
        public void Undo(string commandName)
        {
            GetCommand(commandName).Undo();
        }
    }
    public class A
    {
        public void DoA()
        {
        }
        public void UndoA()
        {
        }
    }
    public class B
    {
        public void DoB()
        {
        }
        public void UndoB()
        {
        }
    }
