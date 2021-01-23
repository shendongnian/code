    //I omitted error checking on all the examples.
    public class Foo : EntityBase { ... }
    void DoSomething<Foo>()
    {
        var someClass = Cache[typeof(Foo)] as ISomeInterface<Foo>
        someClass.Bar();
    }
