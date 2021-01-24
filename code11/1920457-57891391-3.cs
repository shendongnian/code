    public class SomeOtherClass<T, U>
        where T : IFoo
        where U : IBar
    {
        public SomeClass<T, U> Frob { get; set; }
    }
    public class SomeOtherClass<T> : SomeOtherClass<T, IBar>
        where T : IFoo
    {
    }
