    class Program
    {
        static void Main(string[] args)
        {
            string xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
            <getInvoiceReply>
                <invoiceID value=""944659502""/>
                <invFastener>
                    <fastenerID value=""""/>
                    <fastenerName value=""""/>
                    <fastenerCount value=""""/>
                    <fastenerProperty>
                        <propID value=""""/>
                        <propName value=""""/>
                        <propValue value=""""/>
                    </fastenerProperty>
                </invFastener>
            </getInvoiceReply>";
            
            var serializer =  new XmlSerializer(typeof(InvoiceReply));
            var i = (InvoiceReply)serializer.Deserialize(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(xml)));  
            
            Console.ReadKey();
        }
    }
    //Generic class for getting value attribute
    public class ValueElement
    {
        [XmlAttribute("value")]
        public string Value { get; set; }
    }
    [XmlRoot("getInvoiceReply")]
    public class InvoiceReply
    {
        [XmlElement("invoiceID")]
        public ValueElement InvoiceId { get; set; } //This is a value element
        [XmlElement("invFastener")]
        public List<InvFastener> InvFastener { get; set; } //This is an element, not an array
    }
    public class InvFastener
    {
        [XmlElement("fastenerID")]
        public ValueElement FastenerID { get; set; }//This is a value element
        [XmlElement("fastenerName")]
        public ValueElement FastenerName { get; set; }//This is a value element
        [XmlElement("fastenerCount")]
        public ValueElement FastenerCount { get; set; }//This is a value element
        [XmlElement("fastenerProperty")]
        public List<FastenerProperty> FastenerProperties { get; set; } //This is an element, not an array
    }
    public class FastenerProperty
    {
        [XmlElement("propID")]
        public ValueElement PropId { get; set; }//This is a value element
        [XmlElement("propName")]
        public ValueElement PropName { get; set; }//This is a value element
        [XmlElement("propValue")]
        public ValueElement PropValue { get; set; }//This is a value element
    }
