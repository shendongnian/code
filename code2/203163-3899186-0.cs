    public class Base { }
    public class Derived : Base
    {
        public Derived(int a)
            : this() { }
        public Derived()
            : this(42) { }
        static void Main()
        {
            new Derived();
        }
    }
