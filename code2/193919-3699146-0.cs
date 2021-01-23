    public class BINDRequest
    {
        [XmlAttribute]
        public string CLIENT_REQUEST_ID { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            var request = new BINDRequest
            {
                CLIENT_REQUEST_ID = "123"
            };
            var serializer = new XmlSerializer(request.GetType());
            var xmlnsEmpty = new XmlSerializerNamespaces();
            xmlnsEmpty.Add("", "");
            using (var writer = XmlWriter.Create("result.xml"))
            {
                serializer.Serialize(writer, request, xmlnsEmpty);
            }
        }
    }
