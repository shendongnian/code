    public class StackOverflow_8661714
    {
        [DataContract(Name = "SuperClass", Namespace = "WhitespaceTest")]
        [KnownType(typeof(SubClass))]
        public class SuperClass
        {
            [DataMember]
            public string Message { get; set; }
        }
        [DataContract(Name = "SubClass", Namespace = "WhitespaceTest")]
        public class SubClass : SuperClass
        {
            [DataMember]
            public string Extra { get; set; }
        }
        public static void Test()
        {
            string originalJson = "{    \"__type\":\"SubClass:WhitespaceTest\",    \"Message\":\"Message\",    \"Extra\":\"Extra\" }";
            byte[] originalJsonBytes = Encoding.UTF8.GetBytes(originalJson);
            MemoryStream writeStream = new MemoryStream();
            XmlDictionaryWriter jsonWriter = JsonReaderWriterFactory.CreateJsonWriter(writeStream, Encoding.UTF8, false);
            XmlDictionaryReader jsonReader = JsonReaderWriterFactory.CreateJsonReader(originalJsonBytes, 0, originalJsonBytes.Length, XmlDictionaryReaderQuotas.Max);
            jsonWriter.WriteNode(jsonReader, true);
            jsonWriter.Flush();
            Console.WriteLine(Encoding.UTF8.GetString(writeStream.ToArray()));
            writeStream.Position = 0;
            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(SuperClass), new Type[] { typeof(SubClass) });
            object o = dcjs.ReadObject(writeStream);
            Console.WriteLine(o);
        }
    }
