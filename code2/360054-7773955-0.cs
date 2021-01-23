    public class StackOverflow_7760551
    {
        [DataContract]
        public class Person
        {
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public int Age { get; set; }
            public override string ToString()
            {
                return string.Format("Person[Name={0},Age={1}]", this.Name, this.Age);
            }
        }
        public static void Test()
        {
            const string fileName = "test.xml";
            using (FileStream fs = File.Create(fileName))
            {
                Person[] people = new Person[]
                { 
                    new Person { Name = "John", Age = 33 },
                    new Person { Name = "Jane", Age = 28 },
                    new Person { Name = "Jack", Age = 23 }
                };
                foreach (Person p in people)
                {
                    XmlWriterSettings ws = new XmlWriterSettings
                    {
                        Indent = true,
                        IndentChars = "  ",
                        OmitXmlDeclaration = true,
                        Encoding = new UTF8Encoding(false),
                        CloseOutput = false,
                    };
                    using (XmlWriter w = XmlWriter.Create(fs, ws))
                    {
                        DataContractSerializer dcs = new DataContractSerializer(typeof(Person));
                        dcs.WriteObject(w, p);
                    }
                }
            }
            Console.WriteLine(File.ReadAllText(fileName));
            using (FileStream fs = File.OpenRead(fileName))
            {
                XmlReaderSettings rs = new XmlReaderSettings
                {
                    ConformanceLevel = ConformanceLevel.Fragment,
                };
                XmlReader r = XmlReader.Create(fs, rs);
                while (!r.EOF)
                {
                    Person p = new DataContractSerializer(typeof(Person)).ReadObject(r) as Person;
                    Console.WriteLine(p);
                }
            }
            File.Delete(fileName);
        }
    }
