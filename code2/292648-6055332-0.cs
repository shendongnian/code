    public class Root
    {
        [XmlElement("custom-attribute")]
        public Colour Colour { get; set; }
    }
    public class Colour : IXmlSerializable
    {
        [XmlText]
        public string Value { get; set; }
    
        public XmlSchema GetSchema()
        {
            return null;
        }
    
        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }
    
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("dt:dt", "", "string");
            writer.WriteAttributeString("name", "Colour");
            writer.WriteString(Value);
        }
    }
    
    class Program
    {
        static void Main()
        {
            var serializer = new XmlSerializer(typeof(Root));
            var root = new Root
            {
                Colour = new Colour
                {
                    Value = "blue"
                }
            };
            serializer.Serialize(Console.Out, root);
        }
    }
