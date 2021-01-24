        using Newtonsoft.Json;
        using System.Collections.Generic;
        class Program
        {
            static void Main(string[] args)
            {
                var json = @"{
                   ""payload"":[
                      {
                         ""a"":""yes"",
                         ""b"":""no"",
                         ""c"":""maybe""
                      },
                      {
                         ""a1"":""agg"",
                         ""b"":""no"",
                         ""c"":""maybe""
                      },
                      {
                         ""a"":""L"",
                         ""b"":""k"",
                         ""c"":""maybe""
                      }
                   ]
                }";
                var o= JsonConvert.DeserializeObject<RootObject>(json);
                foreach (var item in o.Payload)
                {
                    item.A = "ZZZZZZZZ";
                }
                var convertedJson = JsonConvert.SerializeObject(o);
            
    
            }
        }
    
        public class RootObject
        {
            [JsonProperty("payload")]
            public List<Payload> Payload { get; set; }
        }
    
        public class Payload
        {
            [JsonProperty("a", NullValueHandling = NullValueHandling.Ignore)]
            public string A { get; set; }
    
            [JsonProperty("b")]
            public string B { get; set; }
    
            [JsonProperty("c")]
            public string C { get; set; }
    
            [JsonProperty("a1", NullValueHandling = NullValueHandling.Ignore)]
            public string A1 { get; set; }
        }
