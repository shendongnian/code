    [XmlRoot(ElementName = "class")]
    public class Class
    {
        [XmlElement(ElementName = "custclass")]
        public string Custclass { get; set; }
        [XmlElement(ElementName = "custval")]
        public string Custval { get; set; }
    }
    [XmlRoot(ElementName = "customer")]
    public class Customer
    {
        [XmlElement(ElementName = "group")]
        public string Group { get; set; }
        [XmlElement(ElementName = "class")]
        public List<Class> Class { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }
    [XmlRoot(ElementName = "Reply")]
    public class Reply
    {
        [XmlElement(ElementName = "customer")]
        public Customer Customer { get; set; }
    }
    static async System.Threading.Tasks.Task Main(string[] args)
    {
        string xmlFile = @"xxxxxx.xml";
        using (StreamReader r = new StreamReader(xmlFile))
        {
            string xmlString = r.ReadToEnd();
            XmlSerializer ser = new XmlSerializer(typeof(Reply));
            using (TextReader reader = new StringReader(xmlString))
            {
                var result = (Reply)ser.Deserialize(reader);
                var custvalue = result.Customer.Class.Where(i => i.Custclass == "CD").Select(a => a.Custval).Single();
                Console.WriteLine(custvalue);
            }
        }
    }
