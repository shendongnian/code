    public class NullBar: IBar
    {
       // whatever no-op implementation that makes sense
    }
    
    public class SomeOtherClass<T>
         where T : IFoo
    {
         public SomeClass<T, NullBar> Frob { get; set; }
    }
