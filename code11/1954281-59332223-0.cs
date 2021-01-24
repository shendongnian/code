    public ICollection<Tax> Taxes { get; set; }
    public enum TaxType
    {
        TaxType1 = 0,
        TaxType2 = 1
    }
    public sealed class Tax : ITax
    {
        public TaxType Type { get; set; }
        public decimal BaseTotalAmount { get; set; }
        public decimal TotalAmount { get; set; }
    }
