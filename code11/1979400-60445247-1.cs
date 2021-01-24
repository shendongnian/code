    void Main()
    {
        string jsonText = @"[
          {
            'rank': 1,
            'name': 'name 1',
            'year': '1991'
          },
          {
            'rank': 2,
            'year': '1992'
          },
          {
            'rank': 3,
            'name': 'name 3',
          }
        ]";
    
        JToken json = JToken.Parse(jsonText);
        List<Fields> fields = new List<Fields>
        {
            new Fields
            {
                name = "rank",
                path = "$.[*].rank",
                result = new List<string>()
            },
            new Fields
            {
                name = "name",
                path = "$.[*].name",
                result = new List<string>()
            },
            new Fields
            {
                name = "year",
                path = "$.[*].year",
                result = new List<string>()
            }
        };
        var max = json.SelectTokens("$.[*]").Count().Dump();
        foreach (var field in fields)
        {
            var result = json.SelectTokens(field.path);
            var index = 0;
            foreach (var token in result)
            {
                while(!token.Path.StartsWith($"[{index++}]"))
                    field.result.Add(null);
                if (token is JObject || token is JArray)
                {
                    field.result.Add(token.ToString(Newtonsoft.Json.Formatting.None));
                }
                else
                {
                    field.result.Add(token.ToString());
                }
            }
    		field.result.AddRange(Enumerable.Range(0,max-result.Count()).Select(z=>(string)null));
        }
        fields.Dump();
    }
    
    public class Fields
    {
        public string name { get; set; }
        public string path { get; set; }
        public List<string> result { get; set; }
    }
