    public class StackOverflow_7620718
    {
        public static void Test()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                { "name", "Test object" },
                { "x", 0.5 },
                { "y", 1.25 },
                { "age", 4 },
                { "list-of-strings", new List<string> { "one string", "two string", "last string" } }
            };
            MemoryStream ms = new MemoryStream();
            XmlWriter w = XmlWriter.Create(ms, new XmlWriterSettings
            {
                Indent = true,
                Encoding = new UTF8Encoding(false),
                IndentChars = "  ",
                OmitXmlDeclaration = true,
            });
            DataContractSerializer dcs = new DataContractSerializer(dict.GetType(), new Type[] { typeof(List<string>) });
            dcs.WriteObject(w, dict);
            w.Flush();
            Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
            ms.Position = 0;
            Console.WriteLine("Now deserializing it:");
            Dictionary<string, object> dict2 = (Dictionary<string, object>)dcs.ReadObject(ms);
            foreach (var key in dict2.Keys)
            {
                Console.WriteLine("{0}: {1}", key, dict2[key].GetType().Name);
            }
        }
    }
