    [XmlRoot("foo")]
    public class Foo
    {
        [XmlElement("value")]
        public string Value { get; set; }
    
        public static implicit operator Foo(string s)
        {
            return new Foo { Value = s };
        }
    }
