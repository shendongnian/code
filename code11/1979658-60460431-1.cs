    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    namespace DynamicSerial
    {
        class Program
        {
            static void Main(string[] args)
            {
                var myObject = new Dictionary<string, Object>();
                myObject.Add("Id", 1);
                myObject.Add("Event", new { Name = "SomeName", Id = 2 });
                var mergeObject = new Dictionary<string, Object>();
                mergeObject.Add("Event", new { Location = new { Name = "SomeLocation", Id = 3 } }); //WORKS
                //mergeObject.Add("Event.Location", new { Name = "SomeLocation", Id = 3 }); //DOES NOT WORK
                JObject myDynamicObject = JObject.FromObject(myObject);
                foreach (KeyValuePair<string, Object> kvp in mergeObject)
                {
                    var newObj = new ExpandoObject() as IDictionary<string, Object>;
                    newObj.Add(kvp.Key, kvp.Value);
                    myDynamicObject.Merge(JObject.FromObject(newObj), new JsonMergeSettings
                    {
                        MergeArrayHandling = MergeArrayHandling.Merge
                    });
                }
                Console.WriteLine(JsonConvert.SerializeObject(myDynamicObject));
            }
        }
    }
