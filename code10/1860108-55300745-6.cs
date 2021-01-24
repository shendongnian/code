        public class JsonEntityConverter<TObject> : JsonCreationConverter<TObject>       
        {
            protected override TObject CreateArray<TJsonType>(Type objectType, TJsonType tArray)
            {
                var deserializedObj = default(TObject);
                var jArray = (JArray)Convert.ChangeType(tArray, typeof(JArray));
            
                var newjArray = new JArray();
                foreach (var item in jArray.Children())
                {
                    var itemProperties = item.Children<JProperty>();
                    var jObj = new JObject();
                    foreach (var itemProperty in itemProperties)
                    {                    
                        var name = itemProperty.Name.ToModelName();  // <-- Code Below #3                                     
                    
                        var newJproperty = new JProperty(name, itemProperty.Value);
                    jObj.Add(newJproperty);
                    }
                     newjArray.Add(jObj);
                }
                var sObject = Newtonsoft.Json.JsonConvert.SerializeObject(newjArray);
                deserializedObj = Newtonsoft.Json.JsonConvert.DeserializeObject<TObject>(sObject);
                return deserializedObj;
            }
        }
