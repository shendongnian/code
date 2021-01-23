    public class Money
    {
        public Money(string currency, int amount)
        {
            Currency = currency;
            Amount = amount;
        }
        public int Amount { get; set; }
        public string Currency { get; set; }
    }
