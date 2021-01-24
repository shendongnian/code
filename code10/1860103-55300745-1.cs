        public class JsonEntityConverter<TObject> : JsonCreationConverter<TObject>       
        {
            protected override TObject CreateArray<TJsonType>(Type objectType, TJsonType tArray)
            {
                var deserializedObj = default(TObject);
                var jArray = (JArray)Convert.ChangeType(tArray, typeof(JArray));
            
                foreach (var item in jArray.Children())
                {
                    var itemProperties = item.Children<JProperty>();
                    foreach (var itemProperty in itemProperties)
                    {                    
                        var name = itemProperty.Name.ToModelName();   // <-- Code Below #3                  
                        itemProperty.Rename(name);                    // <-- Code Below #5                    
                    }             
            }
            var sObject = Newtonsoft.Json.JsonConvert.SerializeObject(jArray);
            deserializedObj = Newtonsoft.Json.JsonConvert.DeserializeObject<TObject>(sObject);
            return deserializedObj;
        }
