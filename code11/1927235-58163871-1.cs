    public class MyClass<T>
    {
        private static readonly Shared<string> _Shared
            = new Shared<string>(Guid.Parse("521ecaba-2a5e-43f2-90e0-fda38a32618c"));
    
        public void Set(string value)
        {
            _Shared.Value = value;
        }
    
        public void Get()
        {
            Console.WriteLine(_Shared.Value);
        }
    }
