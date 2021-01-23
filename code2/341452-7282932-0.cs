    public class Test
    {
        public List<byte> Bytes { get; set; }
    }
    var xml = new XmlSerializer(typeof(Test));
    xml.Serialize(File.Open("test.xml",FileMode.OpenOrCreate),
                  new Test
                  {
                      Bytes = new List<byte> {0,1,2,3,4,5,6,7}
                  });
