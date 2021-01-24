    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                XmlSerializer serializer = new XmlSerializer(typeof(Root));
                Root root = (Root)serializer.Deserialize(reader);
            }
        }
        [XmlRoot("root")]
        public class Root
        {
            // Which attributes are needed here?
            private TestEnum TestEnum { get; set; }
            public Element Element
            {
                get { Element e = new Element(); e.testType = TestEnum.ToString(); return e; }
                set { TestEnum = (TestEnum)Enum.Parse(typeof(TestEnum), value.testType); }
            }
        }
        public class Element
        {
            [XmlAttribute]
            public string testType { get; set; }
        }
        public enum TestEnum
        {
            tst1,
            tst2
        }
    }
