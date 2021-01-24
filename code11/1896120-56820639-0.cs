    public static class SerializationInfoExtensions
    {
        public static object GetObject(this SerializationInfo info, string name)
        {
            object value = info.GetValue(name, typeof(object));
            if (value is JObject)
            {
                JObject obj = (JObject)value;
                string typeName = (string)obj["$type"];
                if (typeName != null)
                {
                    Type type = Type.GetType(typeName);
                    if (type != null)
                    {
                        value = obj.ToObject(type);
                    }
                }
            }
            return value;
        }
    }
