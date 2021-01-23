    class Foo
    {
        private string _someString;
        public virtual string SomeString 
        {
            get { return _someString; }
            set { _someString = value; }
        }
    }
    
    class Bar : Foo
    {
        public new string SomeString 
        { 
            get { return base.SomeString; }
            private set { base.SomeString = value; }
        }
    }
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main( string[] args )
            {
                Foo f = new Foo();
                f.SomeString = "whatever";  // works
                Bar b = new Bar();
                b.SomeString = "Whatever";  // error
            }
        }
    }
