    public class A
    {
    }
    public class B
    {
       public A a;
    }
    public class C
    {
        public B b;
    }
    class Program
    {
        static A GetA(C c)
        {
            A myA;
            try
            {
                myA = c.b.a;
            }
            catch
            {
                myA = null;
            }
            return myA;
        }        
        
        static void Main(string[] args)
        {
            C theC = new C();
            theC.b = new B();
            theC.b.a = new A();
            A goodA = GetA(theC);
            if (goodA != null)
            {
                Console.WriteLine("Expected nominal path.");
            }
            else
            {
                Console.WriteLine("Unexpected nominal path.");
            }
            theC.b.a = null;
            A badA = GetA(theC);
            if (badA == null)
            {
                Console.WriteLine("Expected off-nominal path.");
            }
            else
            {
                Console.WriteLine("Unexpected off-nominal path.");
            }
            
        }
    }
