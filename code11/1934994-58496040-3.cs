[
  {
    "name": "USA",
    (...)
  },
  {
    "name": {      
      "en": "Layout",
      "es": "Diseño"      
    },
    (...)
  }    
]
While this is valid json you cannot deserialise it to one class.
You can still get the values though.
using Newtonsoft.Json.Linq;
(...)
var jArr = JArray.Parse(json);
var one = jArr[0].ToObject<Type1>();
var two = jArr[1].ToObject<Type2>();
----
# Models
 public class Country
    {
        public string name { get; set; }
        public string flag { get; set; }
    }
    public class Name
    {
        public string en { get; set; }
        public string es { get; set; }
    }
    public class Label
    {
        public string en { get; set; }
    }
    public class Setting
    {
        public string type { get; set; }
        public string id { get; set; }
        public Label label { get; set; }
    }
    public class Something
    {
        public Name name { get; set; }
        public List<Setting> settings { get; set; }
    }
# Test code
public static async Task Main(string[] args)
    {
        var json = @"[
  {
    ""name"": ""USA"",
    ""flag"": ""usa.jpg"",    
  },
  {
    ""name"": {      
      ""en"": ""Layout"",
      ""es"": ""Diseño""      
    },
    ""settings"": [
      {
        ""type"": ""checkbox"",
        ""id"": ""enabled"",
        ""label"": {
          ""en"": ""Please Select One or More""          
        }
      }
    ]
  }    
]";
        var jArr = JArray.Parse(json);
        var c = jArr[0].ToObject<Country>();
        var s = jArr[1].ToObject<Something>();
        Console.WriteLine(c.flag);
        Console.WriteLine(s.name.es);
        Console.WriteLine(s.settings[0].label.en);
    }
Result
usa.jpg
Diseño
Please Select One or More
I used http://json2csharp.com/ to create the objects. You can use https://app.quicktype.io/#l=cs&r=json2csharp to create both models with C# capitalisation.
For exemple:
public partial class Country
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("flag")]
        public string Flag { get; set; }
    }
