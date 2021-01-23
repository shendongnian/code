    public class FooBase
    {
        protected int value;
        public FooBase() {} // <------------ LOOK HERE
        public FooBase(int value) { this.value = value; }
        public virtual void DoSomething() { throw new NotImplementedException(); }
    }
    public class Foo : FooBase
    {
        public Foo(int value) : base(value) { }
        public override void DoSomething() { Console.WriteLine("Foo: {0}", value); }
    }
    public class FooBar : FooBase
    {
        public FooBar() // <----------------- No error here
        {
        }
        public override void DoSomething() { Console.WriteLine("FooBar: {0}", value); }
    }
