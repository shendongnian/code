    interface IClassTemplate<T> where T : IPropTemplate
    {
        T Template { get; set; }
    }
    public class C3 : IClassTemplate<C1>
    {
        public C1 Template { get; set; }
    }
