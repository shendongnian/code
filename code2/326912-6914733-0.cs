    public class TestViewModel
    {
        public string UpdateProperty { get; set; }
        public string IgnoreProperty { get; set; }
        public ComplexType ComplexProperty { get; set; }
    }
    public class ComplexType
    {
        public long? Code { get; set; }
        public string Name { get; set; }
    }
