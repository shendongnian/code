    public class StackOverflow_8281703
    {
        [XmlType(Namespace = "")]
        public class Foo
        {
            [XmlText]
            public string Value { set; get; }
            [XmlAttribute]
            public string id { set; get; }
        }
        public static void Test()
        {
            MemoryStream ms = new MemoryStream();
            XmlSerializer xs = new XmlSerializer(typeof(Foo));
            Foo foo = new Foo { id = "bar", Value = "some value" };
            xs.Serialize(ms, foo);
            Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
        }
    }
