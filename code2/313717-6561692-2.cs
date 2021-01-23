    [XmlRoot(Namespace = "", IsNullable = false)]
    public class root
    {
        [XmlElement("ModelDescriptor", Form = XmlSchemaForm.Unqualified)]
        public List<ModelDescriptor> Items { get; set; }
    }
    public class ModelDescriptor
    {
        public string Model { get; set; }
    }
