    public class XML
    {
        public static T Deserialize<T>(string input)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (TextReader textReader = new StringReader(input))
            {
                return (T)serializer.Deserialize(textReader);
            }
        }
    }
    public abstract class ResponseBase
    {
        public abstract void PrintResult();
    }
    [XmlRoot("root")]
    public class OldXML : ResponseBase
    {
        [XmlElement("elementOne")]
        public string ElementOne { get; set; }
        [XmlElement("elementTwo")]
        public string ElementTwo { get; set; }
        public override void PrintResult()
        {
            Console.WriteLine("Result is of type 'OldXML': {0}, {1}", ElementOne, ElementTwo);
        }
    }
    [XmlRoot("root")]
    public class NewXML : ResponseBase
    {
        [XmlElement("elementOne")]
        public string ElementOne { get; set; }
        [XmlElement("elementTwo")]
        public string ElementTwo { get; set; }
        [XmlElement("elementThree")]
        public string ElementThree { get; set; }
        public override void PrintResult()
        {
            Console.WriteLine("Result is of type 'NewXML': {0}, {1}, {2}", ElementOne, ElementTwo, ElementThree);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string rootFilePath = @"C:\test\";
            ResponseBase result1 = MethodToDeserializeToBeWritten<OldXML>(File.ReadAllText($"{rootFilePath}oldXML.xml"));
            ResponseBase result2 = MethodToDeserializeToBeWritten<NewXML>(File.ReadAllText($"{rootFilePath}newXML.xml"));
            result1.PrintResult();
            result2.PrintResult();
        }
        static ResponseBase MethodToDeserializeToBeWritten<T>(string fileContent) where T : ResponseBase
        {
            return XML.Deserialize<T>(fileContent);
        }
    }
