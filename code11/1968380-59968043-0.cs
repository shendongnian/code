            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                //get the persisted value
                var s = reader.Value?.ToString();
                var fields = s.Split('|');
                var typeName = ...get the type name from the field
                var type = Type.GetType(typeName);
                //create an object from the remaining fields using the ctor(string value) that
                //each subclass must have
                return System.Activator.CreateInstance(type, new object[] { fields.Skip(1).ToJoinedString("|") });
            }
