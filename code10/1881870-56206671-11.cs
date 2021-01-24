    public class JSONObject
    {
        public int id;
        public string type;
        public string date;
        public string edited;
        public string from;
        public int from_id;
        public string photo;
        public int width;
        public int height;
        [JsonConverter(typeof(TextPropertyConverter))]
        public List<TextProperty> text;
    }
