    public class Person
    {
        [Index(0)]
        public string Name { get; set; }
        [Name("")]
        [Index(1)]
        public string Abc { get; set; }
        [Name("")]
        [Index(2)]
        public string Xyz { get; set; }
        [Index(3)]
        public short Age { get; set; }
        [Name("")]
        [Index(4)]
        public string Foo { get; set; }
        [Name("")]
        [Index(5)]
        public string Blarg { get; set; }
        [Index(6)]
        public string StreetAddress { get; set; }
    }
