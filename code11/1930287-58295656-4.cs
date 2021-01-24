    public class CustomJsonWriter : JsonTextWriter
    {
        public int N { get; set; }
        private int propertyCount = 0;
        public CustomJsonWriter(TextWriter textWriter, int n) : base(textWriter)
        {
            N = n;
        }
        public override void WritePropertyName(string name, bool escape)
        {
            if (propertyCount > 0 && propertyCount % N == 0)
                WriteWhitespace(Environment.NewLine);
            base.WritePropertyName(name, escape);
            propertyCount++;
        }
    }
