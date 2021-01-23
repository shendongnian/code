    public class Product
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        public decimal UnitPrice { get; set; }
    }
