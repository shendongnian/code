    abstract class FooBase
    {
        public abstract void DoSomthingBegin();
        public abstract void DoSomthingEnd();
        public void Foo()
        {
            // Code [Common]
            DoSomthingBegin();
            DoSomthingEnd();
            // Code [Common]
        }
    }
    class FooBegin : FooBase
    {
        public override void DoSomthingBegin()
        {
            Console.WriteLine("OnBegin");
        }
    }
    class FooEnd : FooBase
    {
        public override void DoSomthingBegin()
        {
            Console.WriteLine("OnEnd");
        }
    }
