    public class SomeMyObject : IMyObject {
        // implementation omitted for brevity ...
    }
    // somewhere:
    SomeMyObject obj = MyObjectFactory.Create<SomeMyObject>(rate, date, /* etc. */);
