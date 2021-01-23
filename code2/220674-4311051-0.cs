    public interface IValuableItem
    {
        decimal Amount { get; }
        string Currency { get; }
    }
    public interface IMutableValuable : IValuableItem
    {
        new decimal Amount { set; get; }
        new string Currency { set; get; }
    }
    class Item : IMutableValuable
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
