    static void Main(string[] args) {
        // set culture to invariant
        StringConverter.Default.Culture = CultureInfo.InvariantCulture;
        // add custom converter to default, it will match strings starting with CUSTOM: and return MyCustomClass
        StringConverter.Default.AddConverter(c => c.StartsWith("CUSTOM:"), c => new MyCustomClass(c));
        var items = new[] {"1", "4343434343", "3.33", "true", "false", "2014-10-10 22:00:00", "CUSTOM: something"};
        foreach (var item in items) {
            object result;
            if (StringConverter.Default.TryConvert(item, out result)) {
                Console.WriteLine(result);
            }
        }
        // create new non-default converter
        var localConverter = new StringConverter();
        // add custom converter to parse json which matches schema for MySecondCustomClass
        localConverter.AddConverter((string value, out MySecondCustomClass result) => TryParseJson(value, @"{'value': {'type': 'string'}}", out result));
        {
            object result;
            // check if that works
            if (localConverter.TryConvert("{value: \"Some value\"}", out result)) {
                Console.WriteLine(((MySecondCustomClass) result).Value);
            }
        }
        Console.ReadKey();
    }
    static bool TryParseJson<T>(string json, string rawSchema, out T result) where T : new() {
        // we are using Newtonsoft.Json here
        var parsedSchema = JsonSchema.Parse(rawSchema);
        JObject jObject = JObject.Parse(json);
        if (jObject.IsValid(parsedSchema)) {
            result = JsonConvert.DeserializeObject<T>(json);
            return true;
        }
        else {
            result = default(T);
            return false;
        }
    }
    class MyCustomClass {
        public MyCustomClass(string value) {
            this.Value = value;
        }
        public string Value { get; private set; }
    }
    public class MySecondCustomClass {
        public string Value { get; set; }
    }
