    public class Category
    {
        public string CategoryName { get; set; }
        [XmlElement]
        public List<Product> Products { get; set; }
    }
