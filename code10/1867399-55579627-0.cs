    public class ResponseConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Response);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            //Construct Response from incoming array
            JArray arr = JArray.Load(reader);
            var response = new Response();
            var itemList = new List<Item>();
            foreach (var item in arr)
            {
                var i = new Item();
                i.A = (string)item["A"];
                i.B = (string)item["B"];
                itemList.Add(i);
            }
            response.Items = itemList.ToArray();
            return response;
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    [JsonConverter(typeof(ResponseConverter))]
    public class Response
    {
        public Item[] Items { get; set; }
    }
