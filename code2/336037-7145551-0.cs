    class Program
    {
        static void Main(string[] args)
        {
            TestObject data = new TestObject() { Name = "Claus", Firstname = "Santa"};
            MemoryStream stream = new MemoryStream();
            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add(String.Empty, String.Empty);
            XmlSerializer serializer = new XmlSerializer(typeof(TestObject));
            XmlDictionaryWriter binaryDictionaryWriter = XmlDictionaryWriter.CreateBinaryWriter(stream);
            serializer.Serialize(binaryDictionaryWriter, data,xsn);
            binaryDictionaryWriter.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            StreamReader reader = new StreamReader(stream);
            string s = reader.ReadToEnd();
        }
    }
    [Serializable()]
    public class TestObject
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlIgnore]
        public string Firstname { get; set; }
    }
