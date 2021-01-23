    public class Foo
    {
        public IList<string> AListOfStrings { get; private set; }
    
        public Foo()
        {
            AListOfStrings = new List<string>();
        }
    }
