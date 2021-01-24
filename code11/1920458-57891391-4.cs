    public class SomeOtherClass<T>
        where T : IFoo
    {
        public SomeClass<T, IBar> Frob { get; set; }
    }
