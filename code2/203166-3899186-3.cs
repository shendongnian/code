    // Contains implicit public parameterless constructor
    public class Base { } 
    // Does not contain a constructor with either an explicit or implicit call to base()
    public class Derived : Base
    {
        public Derived(int a)
            : this() { }
        public Derived()
            : this(42) { }
        static void Main()
        {
            new Derived(); //StackOverflowException
        }
    }
