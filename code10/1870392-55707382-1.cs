    [Serializable]
    [JsonConverter(typeof(CurrencyJsonConverter))]
    public class Currency : StringEnumeration<Currency>
    {
        public static Currency CHF = new Currency("CHF", "CHF");
        public static Currency EUR = new Currency("EUR", "EUR");
        public static Currency USD = new Currency("USD", "USD");
        Currency() { }
        Currency(string code, string description) : base(code, description) { }
    }
