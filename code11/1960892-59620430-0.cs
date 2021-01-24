    public class Item
    {
        public string Id { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string UnitOfMeasure { get; set; }
        public int Rate { get; set; }
        public Item() { }
        public Item(string id, DateTime effectiveDate, string unitOfMeasure, int rate)
        {
            Id = id;
            EffectiveDate = effectiveDate;
            UnitOfMeasure = unitOfMeasure;
            Rate = rate;
        }
        public override string ToString()
        {
            return $"{Id} {EffectiveDate.ToShortDateString()} {UnitOfMeasure} {Rate}";
        }
    }
    public class Bill
    {
        public string ItemId { get; set; }
        public DateTime Date { get; set; }
        public override string ToString()
        {
            return $"{ItemId} {Date.ToShortDateString()}";
        }
    }
