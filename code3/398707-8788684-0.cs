    public class Example
    {
        private readonly IDictionary<string, Action> _commands;
        public Example()
        {
            _commands = new Dictionary<string, Action>
                            {
                                {"A", () => (new A()).DoA()}, 
                                {"B", () => (new B()).DoB()}, 
                                {"C", DoStuff}
                            };
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
