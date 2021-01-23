    public class Test
    {
        static void Main()
        {
            var doc = new XmlDocument();
            doc.LoadXml(@"<Test foo=""bar""></Test>");
            var ser = new XmlSerializer(typeof(Test));
            using (var reader = new XmlNodeReader(doc.DocumentElement))
            {
                var test = (Test)ser.Deserialize(reader);
                Console.WriteLine(test.Foo);
            }
        }
        [XmlAttribute("foo")]
        public string Foo { get; set; }
    }
