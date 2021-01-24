    public class Product
    {
        [XmlElement(Order =20)]
        public int ID { get; set; }
    
    }
    public class Fruit : Product
    {
        [XmlElement(Order =30)]
        public int FruitID { get; set; }
        [XmlElement(Order =10)]
        public string Name { get; set; }
    }
