    using System;
    
    public interface IFoo
    {
        void M();
    }
    
    public class A : IFoo
    {
        public virtual void M()
        {
            Console.WriteLine("A.M");
        }
    }
    
    public class B : A
    {
        public override void M()
        {
            base.M();
            Console.WriteLine("B.M");
        }
    }
    
    class Test
    {
        static void Main()
        {
            IFoo foo = new B();
            foo.M();
        }
    }
