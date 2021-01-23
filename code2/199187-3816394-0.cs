    public interface IFoo
    {
        decimal ToDecimal();
    }
    public class Foo : IFoo
    {
        public decimal Value { get; set; }
        public decimal ToDecimal() { return Value; }
    }
