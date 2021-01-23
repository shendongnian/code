    public class Foo
    {
        private readonly string _field;
    
        public Foo(string field)
        {
            Init(out _field, field);
        }
    
        private static void Init(out string assignTo, string value)
        {
            assignTo = value;
        }
    }
