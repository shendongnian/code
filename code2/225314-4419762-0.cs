    public class MyClassList
    {
        [XmlElement("Item")]
        public MyClass[] Items { get; set; }
    }
    var items = new[]
    {
        new MyClass { Property1 = "A", Property2 = "B" },
        new MyClass { Property1 = "C", Property2 = "D" },
    };
    var list = new MyClassList { Items = items };
    
    using (var writer = new StringWriter())
    {
        var xs = new XmlSerializer(typeof(MyClassList), new XmlRootAttribute("Items"));
        xs.Serialize(writer, list);
        writer.ToString().Dump();
    }
