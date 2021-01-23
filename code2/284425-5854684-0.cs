    [XmlTypeAttribute(AnonymousType = true)]
    public class CustomersData
    {
        [XmlElement("CustomerRet")]
        public List<Customer> Customers { get; set; }
    
        public CustomersData()
        {
            Customers = new List<Customer>();
        }
    }
    
    public class Customer
    {
        [XmlElement(ElementName = "ListID")]
        public string ListID { get; set; }
    
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
    
        [XmlElement(ElementName = "FullName")]
        public string FullName { get; set; }
    
        [XmlElement(ElementName = "Phone")]
        public string Phone { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            var xml = 
    @"<?xml version=""1.0"" ?>
    <CustomerQueryRs>
      <CustomerRet>
        <ListID>6BE0000-1159990808</ListID>
        <Name>+ Blaine Bailey</Name>
        <FullName>+ Blaine Bailey</FullName>
        <Phone>866-855-0800</Phone>
      </CustomerRet>
      <CustomerRet>
        <ListID>9BA0000-1165353294</ListID>
        <Name>+ Brian Boyd</Name>
        <FullName>+ Brian Boyd</FullName>
        <Phone>203-245-1877</Phone>
      </CustomerRet>
      <CustomerRet>
        <ListID>9280000-1164147562</ListID>
        <Name>+ Brian Leahy</Name>
        <FullName>+ Brian Leahy</FullName>
        <Phone>508-341-0955</Phone>
      </CustomerRet>
    </CustomerQueryRs>";
            var serializer = new XmlSerializer(typeof(CustomersData), new XmlRootAttribute("CustomerQueryRs"));
            using (var stringReader = new StringReader(xml))
            using (var reader = XmlReader.Create(stringReader))
            {
                var result = (CustomersData)serializer.Deserialize(reader);
                Console.WriteLine(result.Customers[1].FullName);
            }
        }
    }
