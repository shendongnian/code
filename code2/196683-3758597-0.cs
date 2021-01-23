    public class MyModel
    {
        public Item Item { get; set; }
    }
    public class Item
    {
        [DataType(DataType.Time)]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }
    }
