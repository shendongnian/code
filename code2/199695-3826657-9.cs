    public class Foo : IWritableFoo 
    {
        private ConcreteMyVal _myVal;
    
        public ConcreteMyVal MyVal
        {
            get { return _myVal; }
            set { _myVal = value; }
        }
        public IMyValInterface IReadableFoo.MyVal { get { return MyVal; } }
        public IMyValInterface IWritableFoo.MyVal
        {
            // (or use “(ConcreteMyVal)value” if you want it to throw
            set { MyVal = value as ConcreteMyVal; }
        }
    }
