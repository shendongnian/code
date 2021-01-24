    public class Foo
    {
        public Foo(string test)
        {
             if (string.IsNullOrWhiteSpace(test))
                 throw new ArgumentNullException(nameof(test));
    
             Test = test;
        }
        public string Test {get;private set;}
    }
