    public interface IValuableItem<T>
    {
        decimal Amount { get; }
        string Currency { get; }
        T CreateCopy(decimal amount, string currency);
    }
    public class SomeImmutableObject : IValuableItem<SomeImmutableObject>
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }
        public SomeImmutableObject(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
        public SomeImmutableObject CreateCopy(decimal amount, string currency)
        {
            return new SomeImmutableObject(amount, currency);
        }
    }
    SomeImmutableObject obj = new SomeImmutableObject(123.33m, "GBP");
    SomeImmutableObject newObj = obj.CreateCopy(120m, obj.Currency);
