    [XmlTypeAttribute]
    [XmlRootAttribute("MyClass")]
    public class MyClass
    {
        [XmlElementAttribute("Name")]
        public string Name { get; set; }
        [XmlElementAttribute("Bytes")]
        public byte[] Bytes { get; set; }
    }
