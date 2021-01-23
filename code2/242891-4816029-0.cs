    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            var lst = new List<Td>();
            var p = new Panel();
            p.Tr = new List<tr>();
            var tr = new tr();
            p.Tr.Add(tr);
            tr.td = new List<Td>();
            tr.td.Add(new Td() { Element = "Val1" });
            tr.td.Add(new Td() { Element = "Val2" });
            var xmlRel = SerializeObject(p);
            FileStream fs = new FileStream("ser.xml", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(xmlRel);
            sw.Close();
            fs.Close();
        }
        public static String SerializeObject(Object pObject)
        {
            try
            {
                String XmlizedString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(Panel));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                xs.Serialize(xmlTextWriter, pObject);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
                return XmlizedString;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                return null;
            }
        }
        private static String UTF8ByteArrayToString(Byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            String constructedString = encoding.GetString(characters);
            return (constructedString);
        }
    }
    [XmlRoot(ElementName = "panel")]
    public class Panel
    {
        [XmlElementAttribute("tr")]
        public List<tr> Tr { get; set; }
    }
    public class tr
    {
        [XmlElementAttribute("td")]
        public List<Td> td { get; set; }
    }
    public class Td
    {
        [XmlElementAttribute("element")]
        public string Element { get; set; }
    }
    }
