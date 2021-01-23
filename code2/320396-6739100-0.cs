    public class Foo : EntityBase { ... }
    void DoFoo<Foo>()
    {
        var genericValue = (ISomeInterface<Foo>)Cache[typeof(Foo)];
    }
