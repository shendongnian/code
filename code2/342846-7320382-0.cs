    // Factory interface:
    public interface IMyTypeFactory
    {
        IMyType GetByName(string name);
    }
    // Implementation in the composition root:
    public class MyTypeFactory :
        Dictionary<string, Func<IRequestHandler>>, IMyTypeFactory
    {
        public IMyType GetByName(string name) { return this[name](); }
    }
    // Registration
    var factory = new MyTypeFactory
    {
        { "foo", () => new MyType1() },
        { "bar", () => new MyType2() },
        { "boo", () => new MyType3() },
    };
    builder.Register<IMyTypeFactory>(c => factory);
