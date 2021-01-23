    public class City
    {
        [DynamicRegularExpression(PatternProperty = "RegEx")]
        public string Zip { get; set; }
        public string RegEx { get; set; }
    }
