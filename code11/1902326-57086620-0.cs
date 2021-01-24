    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;
    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApp3
    {
        class Link
        {
            public string Addr;
            public short Port;
            public Link() { Addr = "0.0.0.0"; Port = 80; }
            public override string ToString() { return Addr + ":" + Port.ToString(); }
        }
    
        class Targets
        {
            public Link Fixed;
    
            public Dictionary<string, Link> Variable;
    
            public Targets()
            {
                Fixed = new Link() { Addr = "192.168.0.1" };
                Variable = new Dictionary<string, Link>
                {
                    ["Common"] = new Link() { Addr = "192.168.0.2" },
                    ["Common2"] = new Link() { Addr = "192.168.0.25" }
                };
            }
    
            public override string ToString()
            {
                var result = new System.Text.StringBuilder();
    
                result.Append("Fixed").Append('=').Append(Fixed)
                      .Append(' ');
    
                foreach (var link in Variable)
                {
                    if (link.Key != "Variable")
                        result.Append(link.Key).Append('=').Append(link.Value)
                          .Append(' ');
                }
    
                return result.ToString();
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var targets = new Targets();
                var settings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore,
                    Converters = new List<JsonConverter>() { new KeyValuePairConverter() }
                };
    
                JObject o1 = JObject.Parse( @"{
                    'Fixed': { 'Port':12345 },
                    'Variable': {
                        'Common': { 'Port':12345 }
                    }
                }");
                JObject o2 = JObject.FromObject(targets);
                o2.Merge(o1, new JsonMergeSettings
                {
                    // union array values together to avoid duplicates
                    MergeArrayHandling = MergeArrayHandling.Union 
                });
    
                string json = o2.ToString();
    
                Console.WriteLine(json);
                JsonConvert.PopulateObject(json, targets);
    
                Console.WriteLine(targets);
    
                Console.ReadKey();
            }
        }
    }
