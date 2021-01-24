    public class ExcelDocument
    {
        public string SomeValue { get; set; }
        public string SomeOtherValue { get; set; }
        public override string ToString()
        {
            return $"SomeValue: {SomeValue}, SomeOtherValue: {SomeOtherValue}";
        }
    }
