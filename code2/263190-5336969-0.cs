    class Record
    { 
        public MoneyCollection Money { get; set; }
    }
    
    class MoneyCollection
    {
        public MoneyCollection(string currency, params decimal[] amount1) { /*...*/ }
        public decimal[] Amount { get; private set; }
        public string Currency { get; private set; }
        public Money[] Money
        {
          get
          {
            return Amount.Select(x => new Money(Currency, x)).ToArray();
          }
        }
    } 
    
    class Money 
    {
        public Money(decimal amount, string currency ) { /* ... */ }
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }
    }
