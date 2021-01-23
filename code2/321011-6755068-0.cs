    public class StackOverflow_6755014
    {
        public class MyRegex
        {
            public string Regex { get; set; }
        }
        public static class SerializerHelper<T>
        {
            public static string Serialize(T myobject)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                StringWriter stringWriter = new StringWriter();
                xmlSerializer.Serialize(stringWriter, myobject);
                string xml = stringWriter.ToString();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                StringWriter sw = new StringWriter();
                XmlTextWriter xw = new XmlTextWriter(sw);
                xmlDoc.WriteTo(xw);
                return sw.ToString();
            }
            public static T DeSerialize(string xml)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                StringReader stringReader = new StringReader(xml);
                return (T)xmlSerializer.Deserialize(stringReader);
            }
        }
        public static void Test()
        {
            MyRegex original = new MyRegex { Regex = "\\b[1-3]{1}\\b#Must be a value of 1 to 3" };
            string xml = SerializerHelper<MyRegex>.Serialize(original);
            Console.WriteLine("--- SERIALIZE ---");
            Console.WriteLine(xml);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("--- DESERIALIZE ---");
            MyRegex deSerial = SerializerHelper<MyRegex>.DeSerialize(xml);
            Console.WriteLine("Equals? " + (deSerial.Regex.Equals(original.Regex)));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Console.ReadKey();");
            Console.ReadKey();
        }
    }
