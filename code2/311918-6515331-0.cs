        [DataContract]
        public class Person
        {
            [DataMember(Order = 1)]
            public string Name;
            [DataMember(Order = 2)]
            public int Age;
            [DataMember(Order = 3)]
            public Address Address;
        }
        [DataContract]
        public class Address
        {
            [DataMember(Order = 1)]
            public string Street;
            [DataMember(Order = 2)]
            public string City;
            [DataMember(Order = 3)]
            public string State;
        }
        public static void Test()
        {
            MemoryStream ms = new MemoryStream();
            XmlWriterSettings ws = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                Encoding = Encoding.UTF8,
            };
            XmlWriter w = XmlWriter.Create(ms, ws);
            DataContractSerializer dcs = new DataContractSerializer(typeof(Person));
            Person person = new Person
            {
                Name = "John",
                Age = 22,
                Address = new Address
                {
                    Street = "1 Main St.",
                    City = "Springfield",
                    State = "ZZ",
                }
            };
            dcs.WriteObject(w, person);
            w.Flush();
            Console.WriteLine("Serialized:");
            Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
            ms.Position = 0;
            XmlReader r = XmlReader.Create(ms);
            Person deserialized = (Person)dcs.ReadObject(r);
            Console.WriteLine(deserialized);
        }
