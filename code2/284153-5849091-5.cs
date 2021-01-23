    class A
    {
        public delegate void delegateB();
        public delegateB B;
    
        public A() {
          B = virtualB;
        }
        public void virtualB()
        {
            Console.WriteLine("B");
        }
    }
    
    class Program
    {
        class Overrider {
           public void MyB()
           {
               Console.WriteLine("MyB");
           }
        }
    
        public static void Main(string[] Args)
        {
            A a = new A();
            Overrider ovr = new Overrider();
            a.B = ovr.MyB;
            a.B(); // Will print MyB
        }
    }
