    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
        static void Main()
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
                'year': '1993'
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
            }
     
        }
    
        public class Fields
        {
            public string name { get; set; }
            public string path { get; set; }
            public List<string> result { get; set; }
        }
    }
