    interface IClassTemplate
    {
        IPropTemplate Template { get; }
    }
    public class C3 : IClassTemplate
    {
        private readonly C1 c1 = new C1();
        IPropTemplate Template { get { return c1; } }
    }
