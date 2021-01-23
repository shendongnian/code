    [Serializable]
    public class SerializationTest2
    {
        [XmlAttributeAttribute]
        public string MemberA { get; set; }
    }
    [Test]
    public void TestSerialization()
    {
        var d2 = new SerializationTest2();
        d2.MemberA = "test";
        new XmlSerializer(typeof(SerializationTest2))
            .Serialize(File.OpenWrite(@"c:\temp\ser2.xml"), d2);
    }
