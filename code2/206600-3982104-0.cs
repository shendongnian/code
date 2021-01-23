    class A
    {
        public static A operator +(A x, A y)
        {
            A a = new A();
            Console.WriteLine("A+"); // say A
            return a;
        }
    }
    class B
    {
        public static A operator +(A x, B y)
        {
            A a = new A();
            Console.WriteLine("return in:A,B in out:A in class B+"); // say B
            return a;
        }
        public static A operator +(B x, B y)
        {
            A a = new A();
            Console.WriteLine("return in:B,B in out:A in class B +");
            return a;
        }
        // and so on....
    }
   
    B b = new B();
    A a = new A();
    A a1 = new A();
    B b1 = new B();
    a = b + b1; // here you call operator of B, but return A
    a = a + a1; // here you call operator of A and return A
   
