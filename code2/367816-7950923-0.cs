    [XmlRoot("foo")]
    public class Foo
    {
        [XmlElement("bar")]
        public string Bar { get; set; }
    }
    class Program
    {
        static void Main()
        {
            XmlAttributeOverrides xao = new XmlAttributeOverrides();
            xao.Add(typeof(Foo), new XmlAttributes { XmlRoot =
                   new XmlRootAttribute("alpha")});
            xao.Add(typeof(Foo), "Bar", new XmlAttributes { XmlElements = {
                   new XmlElementAttribute("beta") } });
            var ser = new XmlSerializer(typeof (Foo), xao);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("","");
            ser.Serialize(Console.Out, new Foo { Bar = "abc"}, ns);
        }
    }
