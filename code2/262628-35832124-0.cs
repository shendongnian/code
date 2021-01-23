    using System;
    using System.Runtime.Serialization;
    using System.Xml;
    namespace XmlPresharedDictionary
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Serialized sizes");
                Console.WriteLine("-------------------------");
                TestSerialization<MyXmlClassUndecorated>("Undecorated: ");
                TestSerialization<MyXmlClassDecorated>("Decorated:   ");
                Console.ReadLine();
            }
            private static void TestSerialization<T>(string lineComment) where T : new()
            {
                XmlDictionary xmlDict = new XmlDictionary();
                xmlDict.Add("MyElementName1");
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                using (var writer = XmlDictionaryWriter.CreateBinaryWriter(stream, xmlDict))
                {
                    serializer.WriteObject(writer, new T());
                    writer.Flush();
                    Console.WriteLine(lineComment + stream.Length.ToString());
                }
            }
        }
        //[DataContract]
        public class MyXmlClassUndecorated
        {
            public MyElementName1[] MyElementName1 { get; set; }
            public MyXmlClassUndecorated()
            {
                MyElementName1 = new MyElementName1[] { new MyElementName1("A A A A A"), new MyElementName1("A A A A A") };
            }
        }
        [DataContract]
        public class MyXmlClassDecorated
        {
            public MyElementName1[] MyElementName1 { get; set; }
            public MyXmlClassDecorated()
            {
                MyElementName1 = new MyElementName1[] { new MyElementName1("A A A A A"), new MyElementName1("A A A A A") };
            }
        }
        [DataContract]
        public class MyElementName1
        {
            [DataMember]
            public string Value { get; set; }
            public MyElementName1(string value) { Value = value; }
        }
    }
