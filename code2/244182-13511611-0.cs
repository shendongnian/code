    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    namespace MyJsonConverters
    {
        public class AssosiativeArrayConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType.GetInterface(typeof(IDictionary<,>).Name) != null;
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                JObject jObject = JObject.Load(reader);
    
                var result = Activator.CreateInstance(objectType);
                var addMethod = result.GetType().GetMethod("Add");
                var dictionaryTypes = objectType.GetGenericArguments();
    
                foreach (JProperty property in jObject.Properties())
                {
                    var key = Convert.ChangeType(property.Name, dictionaryTypes[0]);
    
                    var value = serializer.Deserialize(property.Value.CreateReader(), dictionaryTypes[1]);
    
                    addMethod.Invoke(result, new[] { key, value });
                }
    
                return result;
            }
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
    }
