    using System;
    using System.IO;
    using System.Xml.Serialization;
    
    [XmlRoot(ElementName = "result")]
    public class Result
    {
        [XmlElement(ElementName = "fwdRate")]
        public double FwdRate { get; set; }
    }
    public class Program
    {
        public static void Main()
        {
            string val = "<result><fwdRate>-9.72316862724032E-05</fwdRate></result>";
            Result response = ParseXML(val);
            Console.WriteLine(response.FwdRate);
        }
        static Result ParseXML(string value)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Result));
            using (TextReader reader = new StringReader(value))
            {
                return serializer.Deserialize(reader) as Result;
            }
        }
    
    }
