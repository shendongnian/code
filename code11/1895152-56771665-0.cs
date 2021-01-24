    public class DomainModel
    {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public string Prop3 { get; set; }
        public string Prop4 { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string json = @"{
                            ""resourceId"": ""0014b07 - 92sl - si90"",
                            ""property"": [
                                {
                                    ""name"": ""prop1"",
                                    ""value"": ""-1.0""
                                },
                                {
                                    ""name"": ""prop2"",
                                    ""value"": ""0.0""
                                },
                                {
                                    ""name"": ""prop3"",
                                    ""value"": ""1000.0""
                                },
                                {
                                    ""name"": ""prop4"",
                                    ""value"": ""Microsoft Windows""
                                },
                                {
                                    ""name"": ""prop5"",
                                    ""value"": ""42917.0""
                                }]
                        }";
            var parsedJason = JObject.Parse(json);
            DomainModel result = new DomainModel();
            var jsonValues = parsedJason["property"].Select(x => ((JObject)x)).ToList();
            var props = typeof(DomainModel).GetProperties();
            jsonValues.ForEach(x =>
            {
                var jsonPropName = x.GetValue("name").ToString();
                var jsonPropValue = x.GetValue("value").ToString();
                var prop = props.Where(p => p.Name.ToUpper() == jsonPropName.Trim().ToUpper()).FirstOrDefault();
                if (prop != null)
                    prop.SetValue(result, jsonPropValue, null);
            });
        }
    }
