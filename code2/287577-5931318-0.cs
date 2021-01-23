    class Program
    {
        static void Main(string[] args)
        {
            ArrayList siteList = new ArrayList();
            ArrayList deserealizedArray = DeserializeArray();
            foreach (var item in deserealizedArray)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---");
            siteList.Add("Test 1");
            siteList.Add("Test 2");
            foreach (var item in siteList)
            {
                Console.WriteLine(item);
            }
            SerializeArray(siteList);
            if (siteList.Contains("Test 2"))
            {
                Console.WriteLine("Test 2 exists!");
                Console.Read();
            }
        }
        public static void SerializeArray(ArrayList siteList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ArrayList));
            TextWriter textWriter = new StreamWriter("SiteList.xml");
            serializer.Serialize(textWriter, siteList);
            textWriter.Close();
        }
        static ArrayList DeserializeArray()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(ArrayList));
            TextReader textReader = new StreamReader("SiteList.xml");
            ArrayList siteList;
            siteList = (ArrayList)deserializer.Deserialize(textReader);
            textReader.Close();
            return siteList;
        }
    }
