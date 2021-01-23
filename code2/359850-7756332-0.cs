    [Test]
    public void XmlOutTest()
    {
        var field = new Field { ExampleField = "TEXT" };
        var property = new Property() { ExampleField = "TEXT" };
        var fieldXml = XmlSerializer<Field>.Serialize(field);
        var propertyXml = XmlSerializer<Property>.Serialize(property);
        System.Console.WriteLine(fieldXml);
        System.Console.WriteLine(propertyXml);
        Assert.IsNotNull(XmlSerializer<Field>.Deserialize(propertyXml));
        Assert.IsNotNull(XmlSerializer<Property>.Deserialize(fieldXml));
    }
    public class Field
    {
        public string ExampleField = string.Empty;
    }
    // changing root so I can use each other's xml when deserializing
    [System.Xml.Serialization.XmlRoot("Field")]
    public class Property
    {
        public string ExampleField { get; set; }
    }
