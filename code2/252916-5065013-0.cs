    public class Base
    {
        public Base(Func<double> func) { }
    }
    
    public class Derived : Base
    {
        public Derived() : base(Method)
        {
        }
    
        public static double Method() { return 1.0; }
    }
