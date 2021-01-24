        using Newtonsoft.Json;
        using Newtonsoft.Json.Linq;
        public class Car
        {
             public string Name {set; get;}
             public string Type {set; get;}
             public string Property {set; get;}
              [JsonExtensionData]
              private IDictionary<string, JToken> _additionalData;
              [OnDeserialized]// this is executed on desirialise..
              private void OnDeserialized(StreamingContext context)
               {
                   Property = (string) context;
                     // the contexts has the value of the Property for each time.
               }
             }
