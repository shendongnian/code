    //
    interface IInterface1
    {
        void SameMethod();
    }
    interface IInterface2
    {
        void SameMethod();
    }
    class TestClass : IInterface1, IInterface2
    {
        void IInterface1.SameMethod()
        {
            // do one thing for Interface 1
        }
        void IInterface2.SameMethod()
        {
            // do something elsefor Interface 2
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TestClass test = new TestClass();
            IInterface1 i1 = test;
            i1.SameMethod(); // will call IInterface1.SameMethod()
            IInterface2 i2 = test;
            i2.SameMethod(); // will call IInterface2.SameMethod()
        }
    }
    
