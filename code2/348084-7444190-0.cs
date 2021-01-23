    public class StringFoo : IFoo<string>
    {
        public T Value { get; set; }
    }
    IFoo<string> fooString = new StringFoo(); // That's fine
    IFoo<object> fooObject = fooString;       // This isn't, because...
    fooObject.Value = new Object();           // ... this would violate type safety
