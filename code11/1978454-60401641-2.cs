    [DelimitedRecord(",")]
    public class Test
    {
        public int SomeInt { get; set; }
        [StringLength(maximumLength: 5)]
        public string SomeString { get; set; }
        public int SomeInt1 { get; set; }
        public override string ToString() =>
            $"{SomeInt} - {SomeString} - {SomeInt1}";
    }
