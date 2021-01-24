    class Program
    {
        static void Main(string[] args)
        {
            string json = "{\"name\":\"a Name\", \"parents\":{\"father\":1, \"mother\":0,},,}";
            using (var stringReader = new StringReader(json))
            {
                using (var jsonReader = new SkipErrorsReader(stringReader))
                {
                    var serializer = new JsonSerializer();
                    dynamic value = serializer.Deserialize(jsonReader);
                    Console.WriteLine(value.parents.father); // prints 1
                }
            }
        }
    }
    class SkipErrorsReader : JsonTextReader
    {
        private static FieldInfo _charPosFieldInfo = typeof(JsonTextReader)
            .GetField("_charPos", BindingFlags.NonPublic | BindingFlags.Instance);
        public SkipErrorsReader(TextReader reader) : base(reader)
        { }
        public override bool Read()
        {
            bool? result;
            do
            {
                try
                {
                    result = base.Read();
                }
                catch
                {
                    result = null;
                    IncrementCharPos();
                }
            } while (result == null);
            return result.Value;
        }
        private void IncrementCharPos()
        {
            int charPos = (int)_charPosFieldInfo.GetValue(this);
            _charPosFieldInfo.SetValue(this, charPos + 1);
        }
    }
