    public class City
    {
        [DynamicReqularExpression(PatternProperty = "RegEx")]
        public string Zip { get; set; }
        public string RegEx { get; set; }
    }
