    public class A
    {
        public virtual void Do() { Console.Write("a"); }
        public void Do2() { Console.Write("a2"); }
    }
    
    public class B : A
    {
        public override void Do() { Console.Write("b"); }
        public new void Do2() { Console.Write("b2"); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            B b = new B();
            A a = b;
            b.Do();               //b
            ( b as A ).Do();      //b
            a.Do();               //b
            ( (A)b ).Do();        //b
            ( b as A ).Do2();     //a2
            ( (A)b ).Do2();       //a2
            ( b ).Do2();          //b2
        }
    }  
    
