    using System;
    
    public interface IFoo
    {
        void M();
    }
    
    public class A : IFoo
    {
        public void M()
        {
            Console.WriteLine("A.M");
        }
    }
    
    public class B : A, IFoo
    {
        public new void M()
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
