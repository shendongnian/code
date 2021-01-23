    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            int b = A.B;
            Console.WriteLine("Read A.B");
            new A();
            Console.WriteLine("Built A");
        }
    }
    
    class A
    {
        public static int B = mystaticfunc();
    
        static int mystaticfunc() {
            Console.WriteLine("Static field");
            return 1;
        }
    
        static A()
        {
            Console.WriteLine("Static constructor");
        }
    
        int C = myfunc();
    
        static int myfunc()
        {
            Console.WriteLine("Field");
            return 1;
        }
    
        public A()
        {
            Console.WriteLine("Constructor");
        }
    }
