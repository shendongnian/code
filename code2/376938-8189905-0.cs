    [AttributeUsage(AttributeTargets.Field)]
    public class EnumDisplayAttribute : Attribute
    {
        public string Description { get; set; }
        public string Code { get; set; }
        public EnumDisplayAttribute()
        {
            Description = description;
            Code = code;
        }
    }
    public enum TransactionType
    {
        [EnumDisplay(Code = "B")] 
        Bill,
        [EnumDisplay(Description = null, Code = "C")]
        CashReceipt,
    }
