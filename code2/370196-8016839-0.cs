    public class StackOverflow_8010677
    {
        [DataContract(Name = "Person", Namespace = "")]
        public class Person
        {
            [DataMember]
            public string Name;
            [DataMember(EmitDefaultValue = false)]
            public int Age;
            private int ageSaved;
            [OnSerializing]
            void OnSerializing(StreamingContext context)
            {
                this.ageSaved = this.Age;
                this.Age = default(int); // will not be serialized
            }
            [OnSerialized]
            void OnSerialized(StreamingContext context)
            {
                this.Age = this.ageSaved;
            }
            public override string ToString()
            {
                return string.Format("Person[Name={0},Age={1}]", this.Name, this.Age);
            }
        }
        public static void Test()
        {
            Person p1 = new Person { Name = "Jane Roe", Age = 23 };
            MemoryStream ms = new MemoryStream();
            DataContractSerializer dcs = new DataContractSerializer(typeof(Person));
            Console.WriteLine("Serializing: {0}", p1);
            dcs.WriteObject(ms, p1);
            Console.WriteLine("   ==> {0}", Encoding.UTF8.GetString(ms.ToArray()));
            Console.WriteLine("   ==> After serialization: {0}", p1);
            Console.WriteLine();
            Console.WriteLine("Deserializing a XML which contains the Age member");
            const string XML = "<Person><Age>33</Age><Name>John Doe</Name></Person>";
            Person p2 = (Person)dcs.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(XML)));
            Console.WriteLine("  ==> {0}", p2);
        }
    }
