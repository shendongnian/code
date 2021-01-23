    public class A: IC
    {
        internal A() { }
    }
    
    public class B: IC
    {
        internal B() { }
    }
    public static class Factory
    {
        public static IC GetObject(int x)
        {
            if (x == 0)
            {
                return new A();
            }
            if (x == 1)
            {
                return new B();
            }
            throw new ArgumentException("x must be 1 or 2", "x");
        }
    }
