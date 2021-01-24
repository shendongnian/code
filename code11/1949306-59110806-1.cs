    namespace ConsoleApp2
    {
        public class Program
        {
    
            static void Main(string[] args)
            {
                C c = new C();
                A a = new A(c);
                B b = new B(c, a);
            }
        }
    
    
        public class A
        {
            public A(C c)
            {
                instanceOfCInA = c;
            }
    
            public C      instanceOfCInA;
            public double a;
            public double b;
        }
        public class B
        {
            public B(C c, A a)
            {
               instanceOfCInB = c;
               instanceOfAInB = a;
            }
    
            public C instanceOfCInB;
            public A instanceOfAInB;
        }
    
        public class C
        {
            //not important
        }
    }
