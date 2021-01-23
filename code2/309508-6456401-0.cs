    [FixedLengthRecord()] 
    public class Order 
    { 
        [FieldFixedLength(5)] 
        public int OrderId; 
         
        [FieldFixedLength(30)] 
        [FieldTrim(TrimMode.Right)] 
        public string CustomerName; 
        [FieldFixedLength(10)] 
        public string SKU; 
      
        [FieldFixedLength(8)] 
        [FieldConverter(typeof(TwoDecimalConverter))] 
        public decimal Price; 
     
        [FieldFixedLength(8)] 
        [FieldConverter(ConverterKind.Date, "ddMMyyyy")] 
        public DateTime AddedDate; 
    }
