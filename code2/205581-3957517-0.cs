    [DelimitedRecord(",") ]
    [IgnoreFirst(1)] 
    public class Product
    {
         
        [CopyMe()] public int ID { get; set; }
        [CopyMe()] public string Description { get; set; }
        
        [FieldConverter(ConverterKind.Decimal)]
        public decimal Val{ get; set; }
    }
