    public class Prog2
    {
        public Prog2()
        {
            var factory = new CommandFactory2();
            factory.Register("A", new Lazy<Action>(() => new A().DoA));
            
            //can use C# Closures 
            B b = null;
            Func<B> my = () => b ?? (b = new B());
            factory.Register("B", new Lazy<Action>(() =>
                                                       {
                                                           var v = my();
                                                           return v.DoB;
                                                       }));
            factory.Register("C", new Lazy<Action>(() => factory.DoStuff));
            factory.Execute("A");
        }
    }
    public class CommandFactory2
    {
        private readonly IDictionary<string, Lazy<Action>> _commands;       
        public void Register(string commandName, Lazy<Action> lazyAction)
        {
            _commands.Add(commandName, lazyAction); 
        }
        public Action GetCommand(string commandName)
        {
            _commands[commandName].Value;
        }
        public void Execute(string commandName)
        {
            GetCommand(commandName)();
        }
        public void DoStuff()
        {
        }
    }
