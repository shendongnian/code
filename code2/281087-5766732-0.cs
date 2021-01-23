    public class A
    {
        public string Foo { get; set; }
        public int Bar { get; set; }
    
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public B BooFar { get; set; }
    }
