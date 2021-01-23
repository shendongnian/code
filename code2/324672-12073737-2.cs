    public class Foo
    {
        private readonly string _field;
        public Foo(string field)
        {
            Init(out _field, field)
        }
    
        private void Init(out string _field, string field)
        {
            _field = field;
        }
    }
