    interface IInterface1
    {
        void Run();
    }
    interface IInterface2
    {
        void Run();
    }
    public class BaseClass : IInterface1, IInterface2
    {
        public void Interface1Run()
        {
            (this as IInterface1).Run();
        }
        public void Interface2Run()
        {
            (this as IInterface2).Run();
        }
        void IInterface2.Run()
        {
            Console.WriteLine("I am from interface 2");
        }
        void IInterface1.Run()
        {
            Console.WriteLine("I am from interface 1");
        }
    }
    public class ChildClass : BaseClass
    {
        public void ChildClassMethod()
        {
            Interface1Run();
            Interface2Run();      
        }
    }
    public class Program : ChildClass
    {
        static void Main(string[] args)
        {
            ChildClass childclass = new ChildClass();
            childclass.ChildClassMethod();
        }
    }
}
