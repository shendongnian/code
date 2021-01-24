    public class item
    {
         public string foo { get; set; }
         public bool bar { get; set; }
    }
    Dictionary<string, bool> keyValuePairs2 = JsonConvert.DeserializeObject<IEnumerable<item>>(json).ToDictionary(x => x.foo, x => x.bar);
