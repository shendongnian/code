    namespace ConsoleApplication1
    {
        public class A
        {
            public virtual void Do() { Console.Write("a"); }
            public void Do2() { Console.Write("a2"); }
        }
        
        public class B : A
        {
            public override void Do() { Console.Write("b"); }
            public void Do2() { Console.Write("b2"); }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                B b = new B();
                b.Do();
                ( b as A ).Do();
                A a = b;
                a.Do();
               ((A)b).Do();
                ( b as A ).Do2();
                ( (A)b ).Do2();
                ( b ).Do2();
            }
        }
    } 
  
    
