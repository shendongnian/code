    namespace JsonConverterTest1
    {
        public class Mapped
        {
            private Dictionary<string, object> _theRest = new Dictionary<string, object>();
            public int One { get; set; }
            public int Two { get; set; }
            public Dictionary<string, object> TheRest { get { return _theRest; } }
        }
    
        public class MappedConverter : CustomCreationConverter<Mapped>
        {
            public override Mapped Create(Type objectType)
            {
                return new Mapped();
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var mappedObj = new Mapped();
                //return base.ReadJson(reader, objectType, existingValue, serializer);
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.PropertyName)
                    {
                        string readerValue = reader.Value.ToString();
                        if (reader.Read())
                        {
                            if (readerValue.Equals("one", StringComparison.InvariantCultureIgnoreCase))
                            {
                                mappedObj.One = Convert.ToInt32(reader.Value);
                            }
                            else if (readerValue.Equals("two", StringComparison.InvariantCultureIgnoreCase))
                            {
                                mappedObj.Two = Convert.ToInt32(reader.Value);
                            }
                            else
                            {
                                mappedObj.TheRest.Add(readerValue, reader.Value);
                            }
                        }
                    }
                }
                return mappedObj;
            }
        }
    
        public class Program
        {
            static void Main(string[] args)
            {
                string json = "{'one':1, 'two':2, 'three':3, 'four':4}";
    
                Mapped mappedObj = JsonConvert.DeserializeObject<Mapped>(json, new MappedConverter());
    
                Console.WriteLine(mappedObj.TheRest["three"].ToString());
                Console.WriteLine(mappedObj.TheRest["four"].ToString());
            }
        }
