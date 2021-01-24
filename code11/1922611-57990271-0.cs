    public class WritableJsonConfigurationProvider : JsonConfigurationProvider
    {
        public WritableJsonConfigurationProvider(JsonConfigurationSource source) : base(source)
        {
        }
        public override void Set(string key, string value)
        {
            base.Set(key,value);
            //Get Whole json file and change only passed key with passed value. It requires modification if you need to support change multi level json structure
            string json = File.ReadAllText(base.Source.Path);
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            jsonObj[key] = value;
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(base.Source.Path, output);
        }
    }
