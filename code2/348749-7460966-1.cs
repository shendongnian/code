    namespace ConsoleApplication1
    {
        public class A
        {
            public virtual void Do() { Console.Write("a"); }
        }
        
        public class B : A
        {
            public override void Do() { Console.Write("b"); }
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
            }
        }
    } 
  
    
