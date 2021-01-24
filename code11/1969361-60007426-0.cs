    [JsonConverter(typeof(StoredDataConverter))]
    public class StoredData
    {
        public int NombreJoueurs;
        public IDictionary<string, pList> Joueurs;
    }
    public class pList
    {
        public string Equipe;
    }
    public class StoredDataConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanRead => base.CanRead;
        public override bool CanWrite => base.CanWrite;
        public override bool CanConvert(Type objectType)
        {
            return typeof(StoredData).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var storedData = new StoredData();
            JObject obj = JObject.Load(reader);
            IDictionary<string, pList> dict = (IDictionary<string, pList>)existingValue ?? new Dictionary<string, pList>();
            foreach (var prop in obj.Properties())
            {
                if (prop.Name != "NombreJoueurs")
                {
                    var jtoken = JToken.Parse(prop.Value.ToString());
                    dict.Add(prop.Name, jtoken.ToObject<pList>());
                }
                else
                    storedData.NombreJoueurs = (int)prop.Value;
            }
            storedData.Joueurs = dict;
            return storedData;
        }
    }
