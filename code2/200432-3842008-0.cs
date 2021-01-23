    interface IFoo
    {
        void Test();
    }
    interface IFoo2
    {
        void Test();
    }
    class Foo : IFoo, IFoo2
    {
        void IFoo.Test() { Trace(); }
        void IFoo2.Test() { Trace(); }
    }
