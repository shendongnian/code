    class MyClass
    {
        static Dictionary<string, Func<MyClass, string, bool>> commands
            = new Dictionary<string, Func<MyClass, string, bool>>
        {
            { "Foo", (@this, x) => @this.Foo(x) },
            { "Bar", (@this, y) => @this.Bar(y) }
        };
        
        public bool Execute(string command, string value)
        {
            return commands[command](this, value);
        }
        
        public bool Foo(string x)
        {
            return x.Length > 3;
        }
        
        public bool Bar(string x)
        {
            return x == "";
        }
    }
