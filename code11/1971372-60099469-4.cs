    public class TestClass
    {
        [XmlAttribute("test1")]
        public string test1 { get; set; }
        [XmlAttribute("test2")]
        public string test2 { get; set; }
    }
    
    var dd = new List<TestClass>();
    dd.Add( new TestClass() { test1 = "asdf", test2 = string.Empty }); //will generate empty attribute for test2
    dd.Add( new TestClass() { test1 = "asdf" }); //the attribute test2 will be ignored
    using (var stringwriter = new System.IO.StringWriter())
    {
       var serializer = new XmlSerializer(dd.GetType());
                
       serializer.Serialize(stringwriter, dd);
       Console.WriteLine( stringwriter.ToString());
    }
