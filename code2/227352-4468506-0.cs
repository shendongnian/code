    using System;
    using System.Xml;
    using System.Xml.Serialization;
    public class Anwer
    {
        public int ID { get; set; }
        public XmlDocument XML { get; set; }
        public Anwer(int ID, string XML)
        {
            this.ID = ID;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(XML);
            this.XML = doc;
        }
        public Anwer()
        { }
    }
    static class Program
    {
        static void Main()
        {
            var answer = new Anwer(123, "<Answer>2</Answer>");
            var ser = new XmlSerializer(answer.GetType());
            ser.Serialize(Console.Out, answer);
        }
    }
