    public interface ISomething
    {
        void DoSomething();
    }
    public class SomeClass : ISomething
    {
        public virtual void DoSomething() { Console.WriteLine("SomeClass"); }
    }
    public class SomeDerivedClass : SomeClass
    {
        private int parameter;
        public SomeDerivedClass(int parameter)
        {
            this.parameter = parameter;
        }
        public virtual void DoSomething()
        {
            Console.WriteLine("SomeDerivedClass - {0}", parameter);
            base.DoSomething();
        }
    }
    public interface IFactory
    {
        public ISomething Create();
    }
    public class SomeClassFactory : IFactory
    {
        public ISomething Create() { return new SomeClass(); }
    }
    public class SomeDerivedClassFactory : IFactory
    {
        public ISomething Create() { return new SomeDerivedClass(SomeParam); }
        public int SomeParam { get; set; }
    }
