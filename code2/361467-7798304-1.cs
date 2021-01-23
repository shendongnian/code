    public abstract class Base { 
        public dynamic Method() { return this; }
    }
    public class Derived1: Base { ... }
    public class Derived2: Base { ... }
    public class Main {
        public static int Main() {
            Derived1 d1 = new Derived1();
            Derived1 x = d1.Method();
            Console.WriteLine(x.GetType()); // outputs Derived1
            Derived2 d2 = new Derived2();
            Derived2 y = d2.Method();
            Console.WriteLine(y.GetType()); // outputs Derived2
        }
    }
