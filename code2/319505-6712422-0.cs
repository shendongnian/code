    public interface IMyInterface
    {
        string Prop1 { get; }
        long Prop2 { get; }
        Guid Prop3 { get; }
        Func<int, bool> Meth { get; }
    }
    //usage:
    dynamic factory = new ClayFactory();
    var iDynamic = factory.MyInterface
    (
        Prop1: "Test",
        Prop2: 42L,
        Prop3: Guid.NewGuid(),
        Meth: new Func<int, bool>(i => i > 5)
    );
    IMyInterface iStatic = iDynamic;
