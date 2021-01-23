    public class Program
    {
        static void Main(string[] args)
        {
    
            B b = new B();
            X.Test(b);
        }
 
        // private does not work here if you want to have a parameter of type A in X
        public abstract class A
        {
            private int _number = 5;
            public int Number { get { return _number; } }
        }
    
        private class B : A
        {
        }
    }
    
    public class X
    {
        public static void Test(Program.A a)
        {
            Console.WriteLine(a.Number);
        }
    }
