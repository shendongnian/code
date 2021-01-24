using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace jsonDeserializeThenSerializeBackQuestion
{
    class Program
    {
        static void Main(string[] args)
        {
			var temp = File.ReadAllText("test.json");
			var data = (JObject)JsonConvert.DeserializeObject(temp);
			var important = data["important"].Value<JObject>().ToString();
			var importantData = JsonConvert.DeserializeObject<Dictionary<string, string>>(important);
            importantData["key1"] = "modified";
            var json = JObject.FromObject(importantData);
            Console.WriteLine(json);
            data["important"] = json;
            var rdyJson = JsonConvert.SerializeObject(data);
            Console.WriteLine(rdyJson);
        }
    }
}
Here is the output that I got:
{
  "key1": "modified",
  "key2": "bbbb",
  "key3": "cccc"
}
{"important":{"key1":"modified","key2":"bbbb","key3":"cccc"},"_meta":{"other":{"default":"a","something":1}}}
Since the data is represented as a JObject and not a string, when you serialize it again it won't escape the double quotes. In your implementation it is setting the json key `important` to be a string, not an actual json object.
EDIT: @Maxim_A answered as I was typing this. That answer is essentially what was stated here.
