        public class Base
        {
            public Base(Func<Base, double> func)
            {
                double result = func(this);
            }
        }
    
        public class Derived : Base
        {
            public Derived() : base(x => Method(x))
            {
            }
    
            private static double Method(Base b) 
            {
                // The documentation would state that the method would only be called
                // from Base using "this" as the first argument
                Derived d = (Derived) b;
            }
        }
