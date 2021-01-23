    public class StackOverflow_7930629
    {
        [DataContract]
        public class Person
        {
            public Person() { }
            public Person(string firstname, string lastname)
            {
                this.FirstName = firstname;
                this.LastName = lastname;
            }
            [DataMember]
            public string FirstName { get; set; }
            [DataMember]
            public string LastName { get; set; }
        }
        public static string Serialize<T>(T obj)
        {
            DataContractJsonSerializer serializer =
                new DataContractJsonSerializer(typeof(T), typeof(T).Name);
            MemoryStream ms = new MemoryStream();
            XmlDictionaryWriter w = JsonReaderWriterFactory.CreateJsonWriter(ms);
            w.WriteStartElement("root");
            w.WriteAttributeString("type", "object");
            serializer.WriteObject(w, obj);
            w.WriteEndElement();
            w.Flush();
            string retVal = Encoding.Default.GetString(ms.ToArray());
            ms.Dispose();
            return retVal;
        }
        public static void Test()
        {
            Console.WriteLine(Serialize(new Person("Jane", "McDoe")));
        }
    }
