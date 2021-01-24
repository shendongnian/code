    public class ExportedType
    {
        public string Value { get; }
        private ExportedType(string value)
        {
            Value = value;
        }
        public static readonly ExportedType CSV = new ExportedType("CSV");
        public static readonly ExportedType XML = new ExportedType("XML");
    }
