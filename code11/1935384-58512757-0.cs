csharp
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace FlattenObject
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = @"
{
  ""abc"": {
    ""123"": {
      ""donkey"": ""hello world"",
      ""kong"": 123
    },
    ""meta"": {
      ""aaa"": ""bbb""
    }
  }
}
";
            var root = JsonConvert.DeserializeObject<JObject>(json);
            var flattened = Flatten(root);
            Console.WriteLine(JsonConvert.SerializeObject(flattened, Formatting.Indented));
        }
        static Dictionary<string, JToken> Flatten(JObject root)
        {
            var result = new Dictionary<string, JToken>();
            void FlattenRec(string path, JToken value)
            {
                if (value is JObject dict)
                {
                    foreach (var pair in dict)
                    {
                        string joinedPath = path != null
                            ? path + "." + pair.Key
                            : pair.Key;
                        FlattenRec(joinedPath, pair.Value);
                    }
                }
                else
                {
                    result[path] = value;
                }
            }
            FlattenRec(null, root);
            return result;
        }
    }
}
gives output:
{
  "abc.123.donkey": "hello world",
  "abc.123.kong": 123,
  "abc.meta.aaa": "bbb"
}
Note: the code above uses local functions which is a recent feature. If you can't use it then create a helper method and pass the result dictionary explicitly.
