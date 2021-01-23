    public class Program
    {
        public class A
        {
            public int f = 3;
        }
        
        public class B
        {
            public int f = 9;
        }
        
        public static void Main(string[] args)
        {            
            B bb = new B();
            Console.WriteLine(bb.f); // writes 9
        }
    }
