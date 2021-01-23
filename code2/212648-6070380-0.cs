    interface IFun
    {
        void Fun();
    }
    abstract class A : IFun
    {
        void IFun.Fun()
        {
            Console.Write("Class A!");
            Fun();
        }
        protected abstract void Fun();
    }
    class B : A
    {
        protected override void Fun()
        {
            Console.Write("Class B!");
        }
    }
    IFun b = new B();
    b.Fun();
