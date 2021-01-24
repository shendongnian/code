    class Program
    {
        static void Main(string[] args)
        {
            TestXml tx = new TestXml();
            tx.Add(new TestXmlElement());
            tx.Add(new TestXmlElement());
            StreamWriter sw = new StreamWriter(@"c:\temp\testproj\test_class.xml");
            XmlSerializer x = new XmlSerializer(typeof(TestXml));
            x.Serialize(sw.BaseStream, tx);
            sw.Close();
        }
    }
