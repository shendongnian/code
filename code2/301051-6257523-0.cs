    public class Program {
        static A? X() {
            Console.WriteLine("X()");
            return new A();
        }
        static B? Y() {
            Console.WriteLine("X()");
            return new B();
        }
        static C? Z() {
            Console.WriteLine("X()");
            return new C();
        }
        public static void Main() {
            C? test = (X() ?? Y()) ?? Z();
        }
    }
