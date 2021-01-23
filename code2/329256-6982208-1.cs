    class Program
    {
        static void Main(string[] args)
        {
            var baseClass = new BaseObject();
            baseClass.Execute();
            var derivedClass = new DerivedObject();
            derivedClass.Execute();
            Console.ReadKey();
        }
    }
    class BaseObject
    {
        public delegate void SomethingDelegate();
        public SomethingDelegate Delegate;
        public BaseObject()
        {
            Delegate += Something;
        }
        public virtual void Something()
        {
            Console.WriteLine("Base Class");
        }
        public void Execute()
        {
            Delegate();
        }
    }
    class DerivedObject : BaseObject
    {
        public override void Something()
        {
            Console.WriteLine("Derived Class");
        }
    }
