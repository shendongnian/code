    /// <summary>
        /// Use KnownType Attribute to match a divierd class based on the class given to the serilaizer
        /// Selected class will be the first class to match all properties in the json object.
        /// </summary>
        public  class KnownTypeConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return System.Attribute.GetCustomAttributes(objectType).Any(v => v is KnownTypeAttribute);
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                // Load JObject from stream
                JObject jObject = JObject.Load(reader);
    
                // Create target object based on JObject
                System.Attribute[] attrs = System.Attribute.GetCustomAttributes(objectType);  // Reflection. 
    
                    // Displaying output. 
                foreach (System.Attribute attr in attrs)
                {
                    if (attr is KnownTypeAttribute)
                    {
                        KnownTypeAttribute k = (KnownTypeAttribute) attr;
                        var props = k.Type.GetProperties();
                        bool found = true;
                        foreach (var f in jObject)
                        {
                            if (!props.Any(z => z.Name == f.Key))
                            {
                                found = false;
                                break;
                            }
                        }
    
                        if (found)
                        {
                            var target = Activator.CreateInstance(k.Type);
                            serializer.Populate(jObject.CreateReader(),target);
                            return target;
                        }
                    }
                }
                throw new ObjectNotFoundException();
    
    
                // Populate the object properties
               
            }
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
